/*
Copyright (c) 2009-2012
All rights reserved.

ժ Ҫ�� ����CryptoAPI�ļ��ܹ���ʵ�֣���.NET Framework����������
		��������Ҫ��ʾCryptoAPI���÷���δ���뿼�Ǵ��������ԴЧ�ʷ��������

��ǰ�汾�� 1.02
�� �ߣ� cqwxj@hotmail.com
���ʱ�䣺2009��08��04��

�޸���ʷ��
2009��08��12�գ�
1��������Կ��������

2012��05��31�գ�
1�����Ӷ�RC4��DES��SHA256��SHA384��SHA512�ȵ�֧��
*/
#define _CRTDBG_MAP_ALLOC
#include <windows.h>
#include <crtdbg.h>
#include <tchar.h>
#include <windowsx.h>
#pragma comment(lib,"crypt32")

#include "resource.h"

// ��װCryptAcquireContext����
__inline BOOL AcquireContext(HCRYPTPROV* phProv,DWORD dwFlags)
{
	return (CryptAcquireContext(phProv,NULL,MS_ENH_RSA_AES_PROV,PROV_RSA_AES,dwFlags) ||
		CryptAcquireContext(phProv,NULL,MS_ENH_RSA_AES_PROV,PROV_RSA_AES,dwFlags|CRYPT_NEWKEYSET) ||
		CryptAcquireContext(phProv,NULL,MS_STRONG_PROV,PROV_RSA_FULL,dwFlags) ||
		CryptAcquireContext(phProv,NULL,MS_STRONG_PROV,PROV_RSA_FULL,dwFlags|CRYPT_NEWKEYSET));
}

// �����������ɶԳ���Կ
__inline BOOL DeriveKey(HCRYPTPROV hProv,const BLOB* pPwd,ALG_ID algidHash,ALG_ID algidSymmetric,DWORD dwKeySize,HCRYPTKEY* phKey)
{
	HCRYPTHASH hHash;
	*phKey =0;
	if(!CryptCreateHash(hProv,algidHash,0,0,&hHash))
		return FALSE;
	if(CryptHashData(hHash,pPwd->pBlobData,pPwd->cbSize,0)) 
	{
		CryptDeriveKey(hProv,algidSymmetric,hHash,MAKELONG(CRYPT_NO_SALT,dwKeySize),phKey);
	}
	CryptDestroyHash(hHash);
	return (*phKey!=0);
}

// ʹ�öԳ���Կ��Կ���ܶ���������
__inline BOOL EncryptBlob(HCRYPTKEY hKey,const BLOB* pInput,LPBLOB pOutput)
{
	pOutput->pBlobData =NULL;
	pOutput->cbSize =pInput->cbSize;
	pOutput->pBlobData =(LPBYTE)malloc(pOutput->cbSize+MAX_PATH);
	if(pOutput->pBlobData!=NULL)
	{
		memcpy(pOutput->pBlobData,pInput->pBlobData,pInput->cbSize);
		if(!CryptEncrypt(hKey,0,TRUE,0,pOutput->pBlobData,&pOutput->cbSize,pOutput->cbSize+MAX_PATH))
		{
			free(pOutput->pBlobData);
			pOutput->pBlobData =NULL;
		}
	}
	return (pOutput->pBlobData!=NULL);
}

// ʹ�öԳ���Կ��Կ���ܶ���������
__inline BOOL DecryptBlob(HCRYPTKEY hKey,const BLOB* pInput,LPBLOB pOutput)
{
	pOutput->pBlobData =NULL;
	pOutput->cbSize =pInput->cbSize;
	pOutput->pBlobData =(LPBYTE)malloc(pOutput->cbSize);
	if(pOutput->pBlobData!=NULL)
	{
		memcpy(pOutput->pBlobData,pInput->pBlobData,pInput->cbSize);
		if(!CryptDecrypt(hKey,0,TRUE,0,pOutput->pBlobData,&pOutput->cbSize))
		{
			free(pOutput->pBlobData);
			pOutput->pBlobData =NULL;
		}
	}
	return (pOutput->pBlobData!=NULL);
}

// �����ɹ�Կ/˽Կ��
BOOL GenPublicPrivateKeyPair(LPBLOB pBlobPublicKey,LPBLOB pBlobPrivateKey,ALG_ID algidAsymmetric,DWORD dwKeySize)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	if(AcquireContext(&hProv,0))
	{
		if(CryptGenKey(hProv,algidAsymmetric,MAKELONG(CRYPT_EXPORTABLE,dwKeySize),&hKey))
		{
			pBlobPublicKey->cbSize =0;
			CryptExportKey(hKey,0,PUBLICKEYBLOB,0,NULL,&pBlobPublicKey->cbSize);
			pBlobPublicKey->pBlobData =(LPBYTE)malloc(pBlobPublicKey->cbSize);
			if(pBlobPublicKey->pBlobData!=NULL)
			{
				CryptExportKey(hKey,0,PUBLICKEYBLOB,0,pBlobPublicKey->pBlobData,&pBlobPublicKey->cbSize);
			}
			pBlobPrivateKey->cbSize =0;
			CryptExportKey(hKey,0,PRIVATEKEYBLOB,0,NULL,&pBlobPrivateKey->cbSize);
			pBlobPrivateKey->pBlobData =(LPBYTE)malloc(pBlobPrivateKey->cbSize);
			if(pBlobPrivateKey->pBlobData!=NULL)
			{
				CryptExportKey(hKey,0,PRIVATEKEYBLOB,0,pBlobPrivateKey->pBlobData,&pBlobPrivateKey->cbSize);
			}
			CryptDestroyKey(hKey);
		}
		CryptReleaseContext(hProv,0);
	}
	return ((pBlobPublicKey->pBlobData!=NULL) && (pBlobPrivateKey->pBlobData!=NULL));
}

// �����Գ���Կ
BOOL ExportKey(const BLOB* pPwd,LPBLOB pOutput,ALG_ID algidHash,DWORD dwKeySize)
{
	HCRYPTPROV hProv;
	HCRYPTHASH hHash;
	DWORD cbSize =0;
	pOutput->pBlobData =NULL;
	pOutput->cbSize =dwKeySize/8;
	if(AcquireContext(&hProv,CRYPT_VERIFYCONTEXT))
	{
		if(CryptCreateHash(hProv,algidHash,0,0,&hHash))
		{
			if(CryptHashData(hHash,pPwd->pBlobData,pPwd->cbSize,0)) 
			{
				CryptGetHashParam(hHash,HP_HASHVAL,NULL,&cbSize,0);
				pOutput->pBlobData =(LPBYTE)malloc(cbSize);
				if(CryptGetHashParam(hHash,HP_HASHVAL,pOutput->pBlobData,&cbSize,0))
				{
					if(cbSize<pOutput->cbSize)
					{
						pOutput->cbSize =cbSize;
					}
				}
				else
				{
					free(pOutput->pBlobData);
					pOutput->pBlobData =NULL;
				}
			}
			CryptDestroyHash(hHash);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pOutput->pBlobData!=NULL);
}

// ʹ��������ܶ���������
// ʵ��ʹ���У����ʹ����ͬ�������μӽ������ݣ��˻���HCRYPTPROV��HCRYPTKEY
BOOL EncryptByPwd(const BLOB* pPwd,const BLOB* pInput,LPBLOB pOutput,ALG_ID algidHash,ALG_ID algidSymmetric,DWORD dwKeySize)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	pOutput->pBlobData = NULL;
	if(AcquireContext(&hProv,CRYPT_VERIFYCONTEXT))
	{
		if((0!=algidHash)?DeriveKey(hProv,pPwd,algidHash,algidSymmetric,dwKeySize,&hKey):
			CryptImportKey(hProv,pPwd->pBlobData,pPwd->cbSize,0,CRYPT_NO_SALT,&hKey))
		{
			EncryptBlob(hKey,pInput,pOutput);
			CryptDestroyKey(hKey);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pOutput->pBlobData!=NULL);
}

// ʹ��������ܶ���������
// ʵ��ʹ���У����ʹ����ͬ�������μӽ������ݣ��˻���HCRYPTPROV��HCRYPTKEY
BOOL DecryptByPwd(const BLOB* pPwd,const BLOB* pInput,LPBLOB pOutput,ALG_ID algidHash,ALG_ID algidSymmetric,DWORD dwKeySize)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	pOutput->pBlobData = NULL;
	if(AcquireContext(&hProv,CRYPT_VERIFYCONTEXT))
	{
		if((0!=algidHash)?DeriveKey(hProv,pPwd,algidHash,algidSymmetric,dwKeySize,&hKey):
			CryptImportKey(hProv,pPwd->pBlobData,pPwd->cbSize,0,CRYPT_NO_SALT,&hKey))
		{
			DecryptBlob(hKey,pInput,pOutput);
			CryptDestroyKey(hKey);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pOutput->pBlobData!=NULL);
}

// ʹ�ù�Կ���ܶ���������
// ʵ��ʹ���У����ʹ����ͬ����Կ��μ������ݣ��˻���HCRYPTPROV��HCRYPTKEY
BOOL EncryptByPublicKey(const BLOB* pKey,const BLOB* pInput,LPBLOB pOutput)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	if(AcquireContext(&hProv,0))
	{
		if(CryptImportKey(hProv,pKey->pBlobData,pKey->cbSize,0,0,&hKey))
		{
			EncryptBlob(hKey,pInput,pOutput);
			CryptDestroyKey(hKey);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pOutput->pBlobData!=NULL);
}

// ʹ��˽Կ���ܶ���������
// ʵ��ʹ���У����ʹ����ͬ����Կ��ν������ݣ��˻���HCRYPTPROV��HCRYPTKEY
BOOL DecryptByPrivateKey(const BLOB* pKey,const BLOB* pInput,LPBLOB pOutput)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	pOutput->pBlobData =NULL;
	if(AcquireContext(&hProv,0))
	{
		if(CryptImportKey(hProv,pKey->pBlobData,pKey->cbSize,0,0,&hKey))
		{
			DecryptBlob(hKey,pInput,pOutput);
			CryptDestroyKey(hKey);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pOutput->pBlobData!=NULL);
}

// ɢ������
BOOL HashData(const BLOB* pBlob,LPBLOB pHash,ALG_ID algidHash)
{
	HCRYPTPROV hProv;
	HCRYPTHASH hHash;
	DWORD cb = sizeof(DWORD);
	pHash->pBlobData =NULL;
	if(AcquireContext(&hProv,CRYPT_VERIFYCONTEXT))
	{
		if(CryptCreateHash(hProv,algidHash,0,0,&hHash))
		{
			if(CryptHashData(hHash,pBlob->pBlobData,pBlob->cbSize,0)) 
			{
				if(CryptGetHashParam(hHash,HP_HASHSIZE,(LPBYTE)&pHash->cbSize,&cb,0))
				{
					pHash->pBlobData =(LPBYTE)malloc(pHash->cbSize);
					if(!CryptGetHashParam(hHash,HP_HASHVAL,pHash->pBlobData,&pHash->cbSize,0))
					{
						free(pHash->pBlobData);
						pHash->pBlobData = NULL;
					}
				}
			}
			CryptDestroyHash(hHash);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pHash->pBlobData!=NULL);
}

// ʹ��˽Կǩ�����������ݣ����������ݵ�ɢ�У���ǩ��ɢ��
// ʵ��ʹ���У����ʹ����ͬ����Կ���ǩ�����ݣ��˻���HCRYPTPROV��HCRYPTKEY
BOOL SignData(const BLOB* pKey,const BLOB* pBlob,LPBLOB pSign,ALG_ID algidHash)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	HCRYPTHASH hHash;
	pSign->pBlobData =NULL;
	if(AcquireContext(&hProv,0))
	{
		if(CryptCreateHash(hProv,algidHash,0,0,&hHash))
		{
			if(CryptHashData(hHash,pBlob->pBlobData,pBlob->cbSize,0)) 
			{
				if(CryptImportKey(hProv,pKey->pBlobData,pKey->cbSize,0,0,&hKey))
				{
					pSign->cbSize =0;
					CryptSignHash(hHash,AT_KEYEXCHANGE,NULL,0,NULL,&pSign->cbSize);
					if(pSign->cbSize)
					{
						pSign->pBlobData =(LPBYTE)malloc(pSign->cbSize);
						if(!CryptSignHash(hHash,AT_KEYEXCHANGE,NULL,0,pSign->pBlobData,&pSign->cbSize))
						{
							free(pSign->pBlobData);
							pSign->pBlobData =NULL;
						}
					}
					CryptDestroyKey(hKey);
				}
			}
			CryptDestroyHash(hHash);
		}
		CryptReleaseContext(hProv,0);
	}
	return (pSign->pBlobData!=NULL);
}

// ʹ��˽Կǩ�����������ݣ����������ݵ�ɢ�У���ǩ��ɢ��
// ʵ��ʹ���У����ʹ����ͬ����Կ�����֤����ǩ�����˻���HCRYPTPROV��HCRYPTKEY
BOOL VerifySign(const BLOB* pKey,const BLOB* pBlob,const BLOB* pSign,ALG_ID algidHash)
{
	HCRYPTPROV hProv;
	HCRYPTKEY hKey;
	HCRYPTHASH hHash;
	BOOL fOK =FALSE;
	if(AcquireContext(&hProv,0))
	{
		if(CryptCreateHash(hProv,algidHash,0,0,&hHash))
		{
			if(CryptHashData(hHash,pBlob->pBlobData,pBlob->cbSize,0)) 
			{
				if(CryptImportKey(hProv,pKey->pBlobData,pKey->cbSize,0,0,&hKey))
				{
					fOK =CryptVerifySignature (hHash,pSign->pBlobData,pSign->cbSize,hKey,NULL,0);
					CryptDestroyKey(hKey);
				}
			}
			CryptDestroyHash(hHash);
		}
		CryptReleaseContext(hProv,0);
	}
	return fOK;
}

// ------------------------------------------------------------------------------------------------

// ���ļ��е��������ݶ�ȡ����������
// Ӧ�ó��������ʵ���ʱ����free�ͷŻ�����
BOOL LoadFile(LPCTSTR pszFile,LPBLOB pBlob)
{
	HANDLE hFile =CreateFile(pszFile,GENERIC_READ,FILE_SHARE_READ,NULL,OPEN_EXISTING,0,NULL);
	if(INVALID_HANDLE_VALUE==hFile)
		return FALSE;
	pBlob->cbSize =GetFileSize(hFile,NULL);
	if(pBlob->cbSize!=0)
	{
		pBlob->pBlobData =(LPBYTE)malloc(pBlob->cbSize);
		if(pBlob->pBlobData!=NULL)
		{
			if(!ReadFile(hFile,pBlob->pBlobData,pBlob->cbSize,&pBlob->cbSize,NULL))
			{
				free(pBlob->pBlobData);
				pBlob->pBlobData =NULL;
				pBlob->cbSize =0;
			}
		}
	}
	CloseHandle(hFile);
	return (pBlob->pBlobData!=NULL);
}

// �Ѷ��������ݱ��浽�½����ļ��С��������ͬ���ļ����򸲸�
BOOL SaveFile(LPCTSTR pszFile,const void* pData,DWORD cbData)
{
	DWORD dwWritten =0;
	HANDLE hFile=CreateFile(pszFile,GENERIC_WRITE,0,NULL,CREATE_ALWAYS,0,NULL);
	if(INVALID_HANDLE_VALUE==hFile)
		return FALSE;
	WriteFile(hFile,pData,cbData,&dwWritten,NULL);
	CloseHandle(hFile);
	return (dwWritten==cbData);
}

// ͨ���򿪶Ի���ָ���ļ�·��
BOOL SelectOpenFile(HWND hDlg,PTSTR pszFile)
{
	OPENFILENAME ofn ={sizeof(OPENFILENAME)};
	*pszFile =0;
	ofn.hwndOwner =hDlg;
	ofn.lpstrFile =pszFile;
	ofn.nMaxFile =MAX_PATH;
	ofn.Flags =OFN_NONETWORKBUTTON;
	return GetOpenFileName(&ofn);
}

// ͨ������Ի���ָ���ļ�·��
BOOL SelectSaveFile(HWND hDlg,PTSTR pszFile)
{
	OPENFILENAME ofn ={sizeof(OPENFILENAME)};
	*pszFile =0;
	ofn.hwndOwner =hDlg;
	ofn.lpstrFile =pszFile;
	ofn.nMaxFile =MAX_PATH;
	ofn.Flags =OFN_NONETWORKBUTTON;
	return GetSaveFileName(&ofn);
}

// ��ȡ������ָ���ĶԳƼ����㷨
__inline ALG_ID GetSymmetricAlgorithm(HWND hDlg)
{
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_AES)==BST_CHECKED)
		return CALG_AES;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_3DES)==BST_CHECKED)
		return CALG_3DES;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_DES)==BST_CHECKED)
		return CALG_DES;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_RC4)==BST_CHECKED)
		return CALG_RC4;
	return CALG_RC2;
}
// ��ȡ������ָ���ĶԳ���Կ����
__inline DWORD GetSymmetricKeySize(HWND hDlg)
{
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_RC2_40)==BST_CHECKED)
		return 40;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_RC2_128)==BST_CHECKED)
		return 128;
	return 0;
}
// ��ȡ������ָ���ķǶԳƼ����㷨
__inline ALG_ID GetAsymmetricAlgorithm(HWND hDlg)
{
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_RSA)==BST_CHECKED)
		return CALG_RSA_KEYX;
	return CALG_DSS_SIGN;
}
// ��ȡ������ָ����ɢ���㷨
__inline ALG_ID GetHashAlgorithm(HWND hDlg)
{
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_SHA512)==BST_CHECKED)
		return CALG_SHA_512;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_SHA384)==BST_CHECKED)
		return CALG_SHA_384;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_SHA256)==BST_CHECKED)
		return CALG_SHA_256;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_SHA1)==BST_CHECKED)
		return CALG_SHA1;
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_MD5)==BST_CHECKED)
		return CALG_MD5;
	return 0;
}

// �ѽ��������õ����뱣�浽ָ���Ļ�����
void UpdatePwd(HWND hDlg,LPBLOB pBlob)
{
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_ASCII)==BST_CHECKED)
	{
		if(pBlob->pBlobData!=NULL)
		{
			free(pBlob->pBlobData);
			pBlob->pBlobData =NULL;
			pBlob->cbSize =0;
		}
		pBlob->cbSize=sizeof(char)*GetWindowTextLengthA(GetDlgItem(hDlg,IDC_EDIT_PWD));
		if(pBlob->cbSize)
		{
			pBlob->cbSize +=sizeof(char);
			pBlob->pBlobData =(LPBYTE)malloc(pBlob->cbSize);
			if(pBlob->pBlobData!=NULL)
			{
				pBlob->cbSize =sizeof(char)*GetDlgItemTextA(hDlg,IDC_EDIT_PWD,(LPSTR)pBlob->pBlobData,pBlob->cbSize/sizeof(char));
			}
		}
	}
	if(IsDlgButtonChecked(hDlg,IDC_RADIO_UNICODE)==BST_CHECKED)
	{
		if(pBlob->pBlobData!=NULL)
		{
			free(pBlob->pBlobData);
			pBlob->pBlobData =NULL;
			pBlob->cbSize =0;
		}
		pBlob->cbSize=sizeof(WCHAR)*GetWindowTextLengthW(GetDlgItem(hDlg,IDC_EDIT_PWD));
		if(pBlob->cbSize)
		{
			pBlob->cbSize +=sizeof(WCHAR);
			pBlob->pBlobData =(LPBYTE)malloc(pBlob->cbSize);
			if(pBlob->pBlobData!=NULL)
			{
				pBlob->cbSize =sizeof(WCHAR)*GetDlgItemTextW(hDlg,IDC_EDIT_PWD,(LPWSTR)pBlob->pBlobData,pBlob->cbSize/sizeof(WCHAR));
			}
		}
	}
}

// ���û�ͨ���򿪶Ի�����ָ����·�����浽�༭����
__inline void SetOpenPath(HWND hDlg,UINT uIDEdit)
{
	TCHAR szFile[MAX_PATH];
	if(SelectOpenFile(hDlg,szFile))
	{
		SetDlgItemText(hDlg,uIDEdit,szFile);
	}
}
// ���û�ͨ������Ի�����ָ����·�����浽�༭����
__inline void SetSavePath(HWND hDlg,UINT uIDEdit)
{
	TCHAR szFile[MAX_PATH];
	if(SelectSaveFile(hDlg,szFile))
	{
		SetDlgItemText(hDlg,uIDEdit,szFile);
	}
}

// �ڱ༭������16������ʾ����������
void SetHex(HWND hDlg,UINT uIDEdit,const BLOB* pBlob)
{
	PTSTR p;
	DWORD dwSize;
	dwSize =pBlob->cbSize*4+MAX_PATH;
	p =(PTSTR)malloc(sizeof(TCHAR)*dwSize);
	if(p!=NULL)
	{
		if(CryptBinaryToString(pBlob->pBlobData,pBlob->cbSize,CRYPT_STRING_HEX,p,&dwSize))
		{
			SetDlgItemText(hDlg,uIDEdit,p);
		}
		free(p);
	}
}

// ����������Ϣ��
__inline void ErrorBox(UINT uIDRes)
{
	TCHAR szText[MAX_PATH];
	LoadString(NULL,uIDRes,szText,MAX_PATH);
	MessageBox(NULL,szText,NULL,MB_OK);
}

// ------------------------------------------------------------------------------------------------

static BLOB g_blobPwd ={0},	// �������ɶԳ���Կ������
	g_blobPublicKey ={0},	// ��Կ
	g_blobPrivateKey={0};	// ˽Կ

// ���ļ��м������룬����˽Կ�����ļ�
__inline void LoadPwd(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	BLOB blob;
	if(NULL==g_blobPrivateKey.pBlobData)
	{
		ErrorBox(IDS_ERROR_LOAD_PWD);
		return;
	}
	if(!SelectOpenFile(hDlg,szFile))
		return;
	if(!LoadFile(szFile,&blob))
		return;
	if(!DecryptByPrivateKey(&g_blobPrivateKey,&blob,&g_blobPwd))
	{
		ErrorBox(IDS_ERROR_DECRYPT);
	}
	else
	{
		CheckRadioButton(hDlg,IDC_RADIO_ASCII,IDC_RADIO_HEX,IDC_RADIO_HEX);
		SetHex(hDlg,IDC_EDIT_PWD,&g_blobPwd);
	}
	free(blob.pBlobData);
}
// �����뱣�浽�ļ��У��ļ��ù�Կ����
__inline void SavePwd(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	BLOB blob;
	LPBLOB pKey =&g_blobPublicKey;
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_NO_PWD);
		return;
	}
	if(NULL==g_blobPublicKey.pBlobData)
	{
		if(NULL==g_blobPrivateKey.pBlobData)
		{
			ErrorBox(IDS_ERROR_SAVE_PWD);
			return;
		}
		pKey =&g_blobPrivateKey;
	}
	if(!SelectSaveFile(hDlg,szFile))
		return;
	if(!EncryptByPublicKey(pKey,&g_blobPwd,&blob))
	{
		ErrorBox(IDS_ERROR_ENCRYPT);
		return;
	}
	SaveFile(szFile,blob.pBlobData,blob.cbSize);
	free(blob.pBlobData);
}
// ����Կ���浽�ļ��У��ļ��ù�Կ����
__inline void SaveKey(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	BLOB blobKey,blob;
	LPBLOB pKey =&g_blobPublicKey;
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_NO_PWD);
		return;
	}
	if(NULL==g_blobPublicKey.pBlobData)
	{
		if(NULL==g_blobPrivateKey.pBlobData)
		{
			ErrorBox(IDS_ERROR_SAVE_PWD);
			return;
		}
		pKey =&g_blobPrivateKey;
	}
	if(!SelectSaveFile(hDlg,szFile))
		return;
	if(ExportKey(&g_blobPwd,&blobKey,GetHashAlgorithm(hDlg),GetSymmetricKeySize(hDlg)))
	{
		if(EncryptByPublicKey(pKey,&blobKey,&blob))
		{
			SaveFile(szFile,blob.pBlobData,blob.cbSize);
			free(blob.pBlobData);
		}
		else
		{
			ErrorBox(IDS_ERROR_ENCRYPT);
		}
		free(blobKey.pBlobData);
	}
	else
	{
		ErrorBox(IDS_ERROR_EXPORT);
	}
}
// ���ɹ�Կ/˽Կ��
__inline void GenKey(HWND hDlg)
{
	if(g_blobPublicKey.pBlobData!=NULL)
	{
		free(g_blobPublicKey.pBlobData);
		g_blobPublicKey.pBlobData =NULL;
	}
	if(g_blobPrivateKey.pBlobData!=NULL)
	{
		free(g_blobPrivateKey.pBlobData);
		g_blobPrivateKey.pBlobData =NULL;
	}
	if(!GenPublicPrivateKeyPair(&g_blobPublicKey,&g_blobPrivateKey,GetAsymmetricAlgorithm(hDlg),(DWORD)GetDlgItemInt(hDlg,IDC_EDIT_KEY_SIZE,NULL,FALSE)))
		return;
	SetHex(hDlg,IDC_EDIT_PUBLIC_KEY,&g_blobPublicKey);
	SetHex(hDlg,IDC_EDIT_PRIVATE_KEY,&g_blobPrivateKey);
}
// ���ļ��м��ع�Կ
__inline void LoadPublicKey(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	if(!SelectOpenFile(hDlg,szFile))
		return;
	if(g_blobPublicKey.pBlobData!=NULL)
	{
		free(g_blobPublicKey.pBlobData);
		g_blobPublicKey.pBlobData =NULL;
	}
	if(LoadFile(szFile,&g_blobPublicKey))
	{
		SetHex(hDlg,IDC_EDIT_PUBLIC_KEY,&g_blobPublicKey);
	}
}
// �ѹ�Կ���浽�ļ���
__inline void SavePublicKey(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	if(!SelectSaveFile(hDlg,szFile))
		return;
	SaveFile(szFile,g_blobPublicKey.pBlobData,g_blobPublicKey.cbSize);
}
// �����뱣�����ļ��м���˽Կ
__inline void LoadPrivateKey(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	BLOB blob;
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_LOAD_PRIVATE_KEY);
		return;
	}
	if(!SelectOpenFile(hDlg,szFile))
		return;
	if(!LoadFile(szFile,&blob))
		return;
	if(g_blobPrivateKey.pBlobData!=NULL)
	{
		free(g_blobPrivateKey.pBlobData);
		g_blobPrivateKey.pBlobData =NULL;
	}
	if(!DecryptByPwd(&g_blobPwd,&blob,&g_blobPrivateKey,GetHashAlgorithm(hDlg),GetSymmetricAlgorithm(hDlg),GetSymmetricKeySize(hDlg)))
	{
		ErrorBox(IDS_ERROR_DECRYPT);
	}
	else
	{
		SetHex(hDlg,IDC_EDIT_PRIVATE_KEY,&g_blobPrivateKey);
	}
	free(blob.pBlobData);
}
// ��˽Կ���浽�ļ��У��ļ������뱣��
__inline void SavePrivateKey(HWND hDlg)
{
	TCHAR szFile[MAX_PATH];
	BLOB blob;
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_SAVE_PRIVATE_KEY);
		return;
	}
	if(!SelectSaveFile(hDlg,szFile))
		return;
	if(!EncryptByPwd(&g_blobPwd,&g_blobPrivateKey,&blob,GetHashAlgorithm(hDlg),GetSymmetricAlgorithm(hDlg),GetSymmetricKeySize(hDlg)))
	{
		ErrorBox(IDS_ERROR_ENCRYPT);
		return;
	}
	SaveFile(szFile,blob.pBlobData,blob.cbSize);
	free(blob.pBlobData);
}

// ����������ļ�
__inline void Encrypt(HWND hDlg)
{
	TCHAR szFileSource[MAX_PATH],szFileDest[MAX_PATH];
	BLOB blobSource,blobDest;
	*szFileSource =0;
	*szFileDest =0;
	GetDlgItemText(hDlg,IDC_EDIT_SOURCE,szFileSource,MAX_PATH);
	GetDlgItemText(hDlg,IDC_EDIT_DEST,szFileDest,MAX_PATH);
	if(0xFFFFFFFF==GetFileAttributes(szFileSource))
	{
		ErrorBox(IDS_ERROR_NO_SOURCE);
		return;
	}
	if(!*szFileDest)
	{
		ErrorBox(IDS_ERROR_NO_DEST);
		return;
	}
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_NO_PWD);
		return;
	}

	if(LoadFile(szFileSource,&blobSource))
	{
		if(!EncryptByPwd(&g_blobPwd,&blobSource,&blobDest,GetHashAlgorithm(hDlg),GetSymmetricAlgorithm(hDlg),GetSymmetricKeySize(hDlg)))
		{
			ErrorBox(IDS_ERROR_ENCRYPT);
		}
		else
		{
			SaveFile(szFileDest,blobDest.pBlobData,blobDest.cbSize);
			free(blobDest.pBlobData);
		}
		free(blobSource.pBlobData);
	}
}

// ����������ļ�
__inline void Decrypt(HWND hDlg)
{
	TCHAR szFileSource[MAX_PATH],szFileDest[MAX_PATH];
	BLOB blobSource,blobDest;
	*szFileSource =0;
	*szFileDest =0;
	GetDlgItemText(hDlg,IDC_EDIT_SOURCE,szFileSource,MAX_PATH);
	GetDlgItemText(hDlg,IDC_EDIT_DEST,szFileDest,MAX_PATH);
	if(0xFFFFFFFF==GetFileAttributes(szFileSource))
	{
		ErrorBox(IDS_ERROR_NO_SOURCE);
		return;
	}
	if(!*szFileDest)
	{
		ErrorBox(IDS_ERROR_NO_DEST);
		return;
	}
	UpdatePwd(hDlg,&g_blobPwd);
	if(NULL==g_blobPwd.pBlobData)
	{
		ErrorBox(IDS_ERROR_NO_PWD);
		return;
	}

	if(LoadFile(szFileSource,&blobSource))
	{
		if(!DecryptByPwd(&g_blobPwd,&blobSource,&blobDest,GetHashAlgorithm(hDlg),GetSymmetricAlgorithm(hDlg),GetSymmetricKeySize(hDlg)))
		{
			ErrorBox(IDS_ERROR_DECRYPT);
		}
		else
		{
			SaveFile(szFileDest,blobDest.pBlobData,blobDest.cbSize);
			free(blobDest.pBlobData);
		}
		free(blobSource.pBlobData);
	}
}

// ����ɢ��
__inline void Hash(HWND hDlg)
{
	TCHAR szFileSource[MAX_PATH],szFileDest[MAX_PATH];
	BLOB blobSource,blobDest;
	*szFileSource =0;
	*szFileDest =0;
	GetDlgItemText(hDlg,IDC_EDIT_SOURCE,szFileSource,MAX_PATH);
	GetDlgItemText(hDlg,IDC_EDIT_DEST,szFileDest,MAX_PATH);
	if(0xFFFFFFFF==GetFileAttributes(szFileSource))
	{
		ErrorBox(IDS_ERROR_NO_SOURCE);
		return;
	}
	if(!*szFileDest)
	{
		ErrorBox(IDS_ERROR_NO_DEST);
		return;
	}

	if(LoadFile(szFileSource,&blobSource))
	{
		if(!HashData(&blobSource,&blobDest,GetHashAlgorithm(hDlg)))
		{
			ErrorBox(IDS_ERROR_HASH);
		}
		else
		{
			SaveFile(szFileDest,blobDest.pBlobData,blobDest.cbSize);
			free(blobDest.pBlobData);
		}
		free(blobSource.pBlobData);
	}
}

// ��˽Կǩ���ļ�
__inline void Sign(HWND hDlg)
{
	TCHAR szFileSource[MAX_PATH],szFileDest[MAX_PATH];
	BLOB blob,blobSign;
	*szFileSource =0;
	*szFileDest =0;
	GetDlgItemText(hDlg,IDC_EDIT_SOURCE,szFileSource,MAX_PATH);
	GetDlgItemText(hDlg,IDC_EDIT_DEST,szFileDest,MAX_PATH);
	if(0xFFFFFFFF==GetFileAttributes(szFileSource))
	{
		ErrorBox(IDS_ERROR_NO_SOURCE);
		return;
	}
	if(!*szFileDest)
	{
		ErrorBox(IDS_ERROR_NO_SIGN);
		return;
	}
	if(NULL==g_blobPrivateKey.pBlobData)
	{
		ErrorBox(IDS_ERROR_NO_PRIVATE_KEY);
	}
	
	if(LoadFile(szFileSource,&blob))
	{
		if(!SignData(&g_blobPrivateKey,&blob,&blobSign,GetHashAlgorithm(hDlg)))
		{
			ErrorBox(IDS_ERROR_SIGN);
		}
		else
		{
			SaveFile(szFileDest,blobSign.pBlobData,blobSign.cbSize);
			free(blobSign.pBlobData);
		}
		free(blob.pBlobData);
	}
}

// �ù�Կ��֤�ļ�ǩ��
__inline void Verify(HWND hDlg)
{
	TCHAR szFileSource[MAX_PATH],szFileDest[MAX_PATH];
	BLOB blob,blobSign;
	LPBLOB pKey =&g_blobPublicKey;
	*szFileSource =0;
	*szFileDest =0;
	GetDlgItemText(hDlg,IDC_EDIT_SOURCE,szFileSource,MAX_PATH);
	GetDlgItemText(hDlg,IDC_EDIT_DEST,szFileDest,MAX_PATH);
	if(0xFFFFFFFF==GetFileAttributes(szFileSource))
	{
		ErrorBox(IDS_ERROR_NO_SOURCE);
		return;
	}
	if(0xFFFFFFFF==GetFileAttributes(szFileDest))
	{
		ErrorBox(IDS_ERROR_NO_SIGN);
		return;
	}
	if(NULL==g_blobPublicKey.pBlobData)
	{
		if(NULL==g_blobPrivateKey.pBlobData)
		{
			ErrorBox(IDS_ERROR_NO_PUBLIC_KEY);
		}
		else
		{
			pKey =&g_blobPrivateKey;
		}
	}
	if(LoadFile(szFileSource,&blob))
	{
		if(LoadFile(szFileDest,&blobSign))
		{
			if(!VerifySign(pKey,&blob,&blobSign,GetHashAlgorithm(hDlg)))
			{
				ErrorBox(IDS_ERROR_VERIFY);
			}
			free(blobSign.pBlobData);
		}
		free(blob.pBlobData);
	}
}

// �Ի��򴰿ڹ���
LRESULT CALLBACK DlgProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	lParam;
	switch (message)
	{
	case WM_INITDIALOG:
		CheckRadioButton (hDlg,IDC_RADIO_RC2_40,IDC_RADIO_3DES,IDC_RADIO_RC2_40);
		CheckRadioButton (hDlg,IDC_RADIO_ASCII,IDC_RADIO_HEX,IDC_RADIO_ASCII);
		CheckRadioButton (hDlg,IDC_RADIO_RSA,IDC_RADIO_DSA,IDC_RADIO_RSA);
		CheckRadioButton (hDlg,IDC_RADIO_MD5,IDC_RADIO_SHA1,IDC_RADIO_MD5);
		SetDlgItemInt(hDlg,IDC_EDIT_KEY_SIZE,512,FALSE);
		return TRUE;
	case WM_DESTROY:
		if(g_blobPwd.pBlobData!=NULL)
		{
			free(g_blobPwd.pBlobData);
			g_blobPwd.pBlobData =NULL;
		}
		if(g_blobPublicKey.pBlobData!=NULL)
		{
			free(g_blobPublicKey.pBlobData);
			g_blobPublicKey.pBlobData =NULL;
		}
		if(g_blobPrivateKey.pBlobData!=NULL)
		{
			free(g_blobPrivateKey.pBlobData);
			g_blobPrivateKey.pBlobData =NULL;
		}
		break;
	case WM_COMMAND:
		switch(LOWORD(wParam))
		{
		case IDC_BUTTON_LOAD_PWD:
			LoadPwd(hDlg);
			break;
		case IDC_BUTTON_SAVE_PWD:
			SavePwd(hDlg);
			break;
		case IDC_BUTTON_SAVE_KEY:
			SaveKey(hDlg);
			break;
		case IDC_BUTTON_GEN_KEY:
			GenKey(hDlg);
			break;
		case IDC_BUTTON_LOAD_PUBLIC:
			LoadPublicKey(hDlg);
			break;
		case IDC_BUTTON_SAVE_PUBLIC:
			SavePublicKey(hDlg);
			break;
		case IDC_BUTTON_LOAD_PRIVATE:
			LoadPrivateKey(hDlg);
			break;
		case IDC_BUTTON_SAVE_PRIVATE:
			SavePrivateKey(hDlg);
			break;
		case IDC_BUTTON_SOURCE:
			SetOpenPath(hDlg,IDC_EDIT_SOURCE);
			break;
		case IDC_BUTTON_DEST:
			SetSavePath(hDlg,IDC_EDIT_DEST);
			break;
		case IDC_BUTTON_ENCRYPT:
			Encrypt(hDlg);
			break;
		case IDC_BUTTON_DECRYPT:
			Decrypt(hDlg);
			break;
		case IDC_BUTTON_HASH:
			Hash(hDlg);
			break;
		case IDC_BUTTON_SIGN:
			Sign(hDlg);
			break;
		case IDC_BUTTON_VERIFY:
			Verify(hDlg);
			break;
		case IDCANCEL:
			EndDialog(hDlg, LOWORD(wParam));
			return TRUE;
		default:
			break;
		}
		break;
	}
	return FALSE;
}

// ------------------------------------------------------------------------------------------------

int APIENTRY _tWinMain(HINSTANCE hInstance,
	 HINSTANCE hPrevInstance,
	 LPTSTR    lpCmdLine,
	 int       nCmdShow)
{
	int tmpFlag = _CrtSetDbgFlag( _CRTDBG_REPORT_FLAG );
	tmpFlag |= _CRTDBG_LEAK_CHECK_DF|_CRTDBG_ALLOC_MEM_DF;
	_CrtSetDbgFlag( tmpFlag );

	hPrevInstance;
	lpCmdLine;
	nCmdShow;
	return (int)DialogBox(hInstance, (LPCTSTR)IDR_MAINFRAME, NULL, (DLGPROC)DlgProc);
}
