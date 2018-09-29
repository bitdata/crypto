import java.io.File;
import java.security.InvalidKeyException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PublicKey;
import java.security.Signature;
import java.security.SignatureException;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.X509EncodedKeySpec;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import sun.misc.BASE64Decoder;

public class VerifyLicense {
	public static void main(String[] args) {
		try {
			String path = args[0];
			DocumentBuilderFactory builderFactory = DocumentBuilderFactory.newInstance();
			DocumentBuilder builder = builderFactory.newDocumentBuilder();
			Document document = builder.parse(new File(path));
			Element rootElement = document.getDocumentElement();
			Element signatureElement = (Element) rootElement.getElementsByTagName("signature").item(0);
			String signature = signatureElement.getTextContent();
			rootElement.removeChild(signatureElement);
			StringBuilder xmlBuilder = new StringBuilder();
			toText(xmlBuilder, rootElement);
			String xml = xmlBuilder.toString();
			System.out.println(xml);
			System.out.println(xml.length());
			boolean ret = verify(xml.getBytes("UTF8"), new BASE64Decoder().decodeBuffer(signature));
			System.out.println(ret);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public static boolean verify(byte[] data, byte[] sign)
			throws InvalidKeySpecException, NoSuchAlgorithmException, InvalidKeyException, SignatureException {
		/*
		 * MIIBuDCCASwGByqGSM44BAEwggEfAoGBAP1/U4EddRIpUt9KnC7s5Of2EbdSPO9EAMMeP4C2USZp
		 * RV1AIlH7WT2NWPq/xfW6MPbLm1Vs14E7gB00b/JmYLdrmVClpJ+f6AR7ECLCT7up1/63xhv4O1fn
		 * xqimFQ8E+4P208UewwI1VBNaFpEy9nXzrith1yrv8iIDGZ3RSAHHAhUAl2BQjxUjC8yykrmCouuE
		 * C/BYHPUCgYEA9+GghdabPd7LvKtcNrhXuXmUr7v6OuqC+VdMCz0HgmdRWVeOutRZT+ZxBxCBgLRJ
		 * FnEj6EwoFhO3zwkyjMim4TwWeotUfI0o4KOuHiuzpnWRbqN/C/ohNWLx+2J6ASQ7zKTxvqhRkImo
		 * g9/hWuWfBpKLZl6Ae1UlZAFMO/7PSSoDgYUAAoGBAK7WWxTWf/UbGSm/STXFArquAZC2ia76uq6n
		 * tfhkMOYs6LjBKuZ6M5675zdi6nFz1IJC9ZteMCB3U3COabDmIHuWWVovfNRNz/Wly9KdbwcFkcDh
		 * MXvja3oM7ordJYFkzBgfj6bzDtLVLA59wcJbIPdrGnyaMhfYZC6198VI3NBg
		 */
		byte[] keyBytes = { 48, -126, 1, -72, 48, -126, 1, 44, 6, 7, 42, -122, 72, -50, 56, 4, 1, 48, -126, 1, 31, 2,
				-127, -127, 0, -3, 127, 83, -127, 29, 117, 18, 41, 82, -33, 74, -100, 46, -20, -28, -25, -10, 17, -73,
				82, 60, -17, 68, 0, -61, 30, 63, -128, -74, 81, 38, 105, 69, 93, 64, 34, 81, -5, 89, 61, -115, 88, -6,
				-65, -59, -11, -70, 48, -10, -53, -101, 85, 108, -41, -127, 59, -128, 29, 52, 111, -14, 102, 96, -73,
				107, -103, 80, -91, -92, -97, -97, -24, 4, 123, 16, 34, -62, 79, -69, -87, -41, -2, -73, -58, 27, -8,
				59, 87, -25, -58, -88, -90, 21, 15, 4, -5, -125, -10, -45, -59, 30, -61, 2, 53, 84, 19, 90, 22, -111,
				50, -10, 117, -13, -82, 43, 97, -41, 42, -17, -14, 34, 3, 25, -99, -47, 72, 1, -57, 2, 21, 0, -105, 96,
				80, -113, 21, 35, 11, -52, -78, -110, -71, -126, -94, -21, -124, 11, -16, 88, 28, -11, 2, -127, -127, 0,
				-9, -31, -96, -123, -42, -101, 61, -34, -53, -68, -85, 92, 54, -72, 87, -71, 121, -108, -81, -69, -6,
				58, -22, -126, -7, 87, 76, 11, 61, 7, -126, 103, 81, 89, 87, -114, -70, -44, 89, 79, -26, 113, 7, 16,
				-127, -128, -76, 73, 22, 113, 35, -24, 76, 40, 22, 19, -73, -49, 9, 50, -116, -56, -90, -31, 60, 22,
				122, -117, 84, 124, -115, 40, -32, -93, -82, 30, 43, -77, -90, 117, -111, 110, -93, 127, 11, -6, 33, 53,
				98, -15, -5, 98, 122, 1, 36, 59, -52, -92, -15, -66, -88, 81, -112, -119, -88, -125, -33, -31, 90, -27,
				-97, 6, -110, -117, 102, 94, -128, 123, 85, 37, 100, 1, 76, 59, -2, -49, 73, 42, 3, -127, -123, 0, 2,
				-127, -127, 0, -82, -42, 91, 20, -42, 127, -11, 27, 25, 41, -65, 73, 53, -59, 2, -70, -82, 1, -112, -74,
				-119, -82, -6, -70, -82, -89, -75, -8, 100, 48, -26, 44, -24, -72, -63, 42, -26, 122, 51, -98, -69, -25,
				55, 98, -22, 113, 115, -44, -126, 66, -11, -101, 94, 48, 32, 119, 83, 112, -114, 105, -80, -26, 32, 123,
				-106, 89, 90, 47, 124, -44, 77, -49, -11, -91, -53, -46, -99, 111, 7, 5, -111, -64, -31, 49, 123, -29,
				107, 122, 12, -18, -118, -35, 37, -127, 100, -52, 24, 31, -113, -90, -13, 14, -46, -43, 44, 14, 125,
				-63, -62, 91, 32, -9, 107, 26, 124, -102, 50, 23, -40, 100, 46, -75, -9, -59, 72, -36, -48, 96 };
		PublicKey key = KeyFactory.getInstance("DSA").generatePublic(new X509EncodedKeySpec(keyBytes));
		Signature signature = Signature.getInstance("DSA");
		signature.initVerify(key);
		signature.update(data);
		return signature.verify(sign);
	}

	private static void toText(StringBuilder builder, Element element) {
		builder.append("<");
		builder.append(element.getTagName());
		NamedNodeMap attributes = element.getAttributes();
		for (int i = 0; i < attributes.getLength(); i++) {
			builder.append(" ");
			builder.append(attributes.item(i).getNodeName());
			builder.append("=\"");
			builder.append(attributes.item(i).getNodeValue());
			builder.append("\"");
		}
		builder.append(">\n");
		NodeList nodes = element.getChildNodes();
		for (int j = 0; j < nodes.getLength(); j++) {
			Node node = nodes.item(j);
			if (node instanceof Element) {
				toText(builder, (Element) node);
			} else {
				String content = node.getTextContent().trim();
				if (content.length() != 0) {
					builder.append("\n");
					builder.append(content);
					builder.append("\n \n");
				}
			}
		}
		builder.append("</");
		builder.append(element.getTagName());
		builder.append(">\n");
	}
}