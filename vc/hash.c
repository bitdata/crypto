/*
 * hash.c
 * Calc file's hash value by WIN32 crypto API.
 
 * Version: 1.00.00

 * Copyright (c) 2010, Wang Xiaojian <cqwxj@hotmail.com>,
 * Bit R&D Studio. All rights reserved.

 * THIS SOFTWARE IS PROVIDED BY THE INSTITUTE AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE INSTITUTE OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */

#include <windows.h>
#include <tchar.h>
#pragma comment(lib,"crypt32")

// 封装CryptAcquireContext函数
__inline BOOL AcquireContext(HCRYPTPROV* phProv,ALG_ID algid)
{
	LPCTSTR pszProvider;
	DWORD dwProvType;
	switch(algid)
	{
	case CALG_SHA_256:
	case CALG_SHA_384:
	case CALG_SHA_512:
		pszProvider =MS_ENH_RSA_AES_PROV;
		dwProvType =PROV_RSA_AES;
		break;
	default:
		pszProvider =MS_DEF_PROV;
		dwProvType =PROV_RSA_FULL;
		break;
	}
	
	return (CryptAcquireContext(phProv,NULL,pszProvider,dwProvType,0) ||
		CryptAcquireContext(phProv,NULL,pszProvider,dwProvType,CRYPT_NEWKEYSET));
}

// 计算文件的hash
// 参数说明：
// pszFile		[in, string] 文件路径名称
// pHashData	[out, size_is(cbMaxSize)] 指向接收hash的缓冲区地址
// cbMaxSize	[in] 接收hash的缓冲区长度，以字节为单位
// algid		[in] hash算法
// 返回值：
// 填充pHashData的数据长度，以字节为单位
DWORD GetFileHash(LPCTSTR pszFile,PBYTE pHashData,DWORD cbMaxSize,ALG_ID algid)
{
	HCRYPTPROV hProv;
	HCRYPTHASH hHash;
	DWORD cbRead,cb =0,cbSize =cbMaxSize;
	BYTE pBuffer[2048];
	HANDLE hFile =CreateFile(pszFile,GENERIC_READ,FILE_SHARE_READ,NULL,OPEN_EXISTING,0,NULL);
	if(INVALID_HANDLE_VALUE!=hFile)
	{
		if(AcquireContext(&hProv,algid))
		{
			if(CryptCreateHash(hProv,algid,0,0,&hHash))
			{
				while(ReadFile(hFile,pBuffer,sizeof(pBuffer),&cbRead,NULL))
				{
					if(0==cbRead)
						break;
					if(!CryptHashData(hHash,pBuffer,cbRead,0)) 
						break;
				}
				if(CryptGetHashParam(hHash,HP_HASHVAL,pHashData,&cbSize,0))
				{
					cb =cbSize;
				}
				CryptDestroyHash(hHash);
			}
			CryptReleaseContext(hProv,0);
		}
		CloseHandle(hFile);
	}
	return cb;
}

// 计算文件hash
// 参数说明：
// pszFile	[in, string] 指向包含待计算hash的文件路径字符串的缓冲区地址
// algid	[in] hash算法
void ShowHash(LPCTSTR pszFile,ALG_ID algid)
{
	BYTE pHashData[128];
	TCHAR szText[1024];
	DWORD cb =sizeof(szText)/sizeof(TCHAR);
	DWORD cbHash =GetFileHash(pszFile,pHashData,sizeof(pHashData),algid);
	if(cbHash!=0)
	{
		if(CryptBinaryToString(pHashData,cbHash,CRYPT_STRING_HEX,szText,&cb))
		{
			MessageBox(NULL,szText,pszFile,MB_OK);
		}
	}
}

// 把可执行文件名转换为算法
const struct 
{
	ALG_ID algid;
	LPCTSTR name;
}rgAlgs[] =
{
	{CALG_MD2,_T("md2")},
	{CALG_MD5,_T("md5")},
	{CALG_SHA,_T("sha")},
	{CALG_SHA1,_T("sha1")},
	{CALG_SHA_256,_T("sha256")},
	{CALG_SHA_384,_T("sha384")},
	{CALG_SHA_512,_T("sha512")},
	{CALG_MAC,_T("mac")},
	{CALG_HMAC,_T("hmac")}
};

int APIENTRY _tWinMain(HINSTANCE hInstance,
	 HINSTANCE hPrevInstance,
	 LPTSTR    lpCmdLine,
	 int       nCmdShow)
{
	TCHAR szFile[MAX_PATH];
	ALG_ID algid =0;
	LPCTSTR pszFile;
	int i;

	hPrevInstance;
	nCmdShow;
	GetModuleFileName(hInstance,szFile,MAX_PATH);
	pszFile =_tcsrchr(szFile,_T('\\'))+1;
	*_tcsrchr(pszFile,_T('.')) =0;
	for(i=sizeof(rgAlgs)/sizeof(rgAlgs[0])-1;i>=0;i--)
	{
		if(lstrcmpi(pszFile,rgAlgs[i].name)==0)
		{
			algid =rgAlgs[i].algid;
			break;
		}
	}
	if(i<0)
		return -1;
	if(0==*lpCmdLine)
	{
		OPENFILENAME ofn ={sizeof(OPENFILENAME)};
		*szFile =0;
		ofn.hwndOwner =NULL;
		ofn.lpstrFile =szFile;
		ofn.nMaxFile =MAX_PATH;
		ofn.Flags =OFN_NONETWORKBUTTON|OFN_FILEMUSTEXIST;
		if(!GetOpenFileName(&ofn))
			return -1;
		ShowHash(szFile,algid);
	}
	else
	{
		if(0xFFFFFFFF==GetFileAttributes(lpCmdLine))
			return -1;
		ShowHash(lpCmdLine,algid);
	}
	return 0;
}
