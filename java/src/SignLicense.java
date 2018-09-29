import java.io.File;
import java.security.InvalidKeyException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.Signature;
import java.security.SignatureException;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.PKCS8EncodedKeySpec;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import sun.misc.BASE64Encoder;

public class SignLicense {
	public static void main(String[] args) {
		try {
			String path = args[0];
			DocumentBuilderFactory builderFactory = DocumentBuilderFactory.newInstance();
			DocumentBuilder builder = builderFactory.newDocumentBuilder();
			Document document = builder.parse(new File(path));
			Element rootElement = document.getDocumentElement();
			Element signatureElement = (Element) rootElement.getElementsByTagName("signature").item(0);
			if (signatureElement != null) {
				rootElement.removeChild(signatureElement);
			}
			StringBuilder xmlBuilder = new StringBuilder();
			toText(xmlBuilder, rootElement);
			String xml = xmlBuilder.toString();
			System.out.println(xml);
			System.out.println(xml.length());
			byte[] bytes = sign(xml.getBytes("UTF8"));
			System.out.println(VerifyLicense.verify(xml.getBytes("UTF-8"), bytes));
			String signature = new BASE64Encoder().encode(bytes);
			signatureElement = document.createElement("signature");
			signatureElement.setTextContent(signature);
			rootElement.appendChild(signatureElement);
			TransformerFactory transformerFactory = TransformerFactory.newInstance();
			Transformer transformer = transformerFactory.newTransformer();
			DOMSource source = new DOMSource(document);
			transformer.setOutputProperty(OutputKeys.ENCODING, "utf-8");
			transformer.setOutputProperty(OutputKeys.INDENT, "yes");
			transformer.setOutputProperty(OutputKeys.OMIT_XML_DECLARATION, "yes");
			StreamResult result = new StreamResult(new File(path));
			transformer.transform(source, result);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static byte[] sign(byte[] data)
			throws NoSuchAlgorithmException, InvalidKeySpecException, InvalidKeyException, SignatureException {
		byte[] keyBytes = new byte[] { 48, -126, 1, 75, 2, 1, 0, 48, -126, 1, 44, 6, 7, 42, -122, 72, -50, 56, 4, 1, 48,
				-126, 1, 31, 2, -127, -127, 0, -3, 127, 83, -127, 29, 117, 18, 41, 82, -33, 74, -100, 46, -20, -28, -25,
				-10, 17, -73, 82, 60, -17, 68, 0, -61, 30, 63, -128, -74, 81, 38, 105, 69, 93, 64, 34, 81, -5, 89, 61,
				-115, 88, -6, -65, -59, -11, -70, 48, -10, -53, -101, 85, 108, -41, -127, 59, -128, 29, 52, 111, -14,
				102, 96, -73, 107, -103, 80, -91, -92, -97, -97, -24, 4, 123, 16, 34, -62, 79, -69, -87, -41, -2, -73,
				-58, 27, -8, 59, 87, -25, -58, -88, -90, 21, 15, 4, -5, -125, -10, -45, -59, 30, -61, 2, 53, 84, 19, 90,
				22, -111, 50, -10, 117, -13, -82, 43, 97, -41, 42, -17, -14, 34, 3, 25, -99, -47, 72, 1, -57, 2, 21, 0,
				-105, 96, 80, -113, 21, 35, 11, -52, -78, -110, -71, -126, -94, -21, -124, 11, -16, 88, 28, -11, 2,
				-127, -127, 0, -9, -31, -96, -123, -42, -101, 61, -34, -53, -68, -85, 92, 54, -72, 87, -71, 121, -108,
				-81, -69, -6, 58, -22, -126, -7, 87, 76, 11, 61, 7, -126, 103, 81, 89, 87, -114, -70, -44, 89, 79, -26,
				113, 7, 16, -127, -128, -76, 73, 22, 113, 35, -24, 76, 40, 22, 19, -73, -49, 9, 50, -116, -56, -90, -31,
				60, 22, 122, -117, 84, 124, -115, 40, -32, -93, -82, 30, 43, -77, -90, 117, -111, 110, -93, 127, 11, -6,
				33, 53, 98, -15, -5, 98, 122, 1, 36, 59, -52, -92, -15, -66, -88, 81, -112, -119, -88, -125, -33, -31,
				90, -27, -97, 6, -110, -117, 102, 94, -128, 123, 85, 37, 100, 1, 76, 59, -2, -49, 73, 42, 4, 22, 2, 20,
				70, -128, -31, -74, 96, 23, 115, -75, -22, -15, 22, 69, -38, 127, 55, 34, -21, -27, -20, -74 };
		PKCS8EncodedKeySpec pkcs8KeySpec = new PKCS8EncodedKeySpec(keyBytes);
		KeyFactory keyFactory = KeyFactory.getInstance("DSA");
		PrivateKey key = keyFactory.generatePrivate(pkcs8KeySpec);
		Signature signature = Signature.getInstance("DSA");
		signature.initSign(key);
		signature.update(data);
		return signature.sign();
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