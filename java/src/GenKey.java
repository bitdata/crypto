import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.lang.StringBuilder;
import sun.misc.BASE64Encoder;

public class GenKey {
	public static void main(String[] args) {
		try {
			KeyPairGenerator keyPairGen = KeyPairGenerator.getInstance("DSA");
			keyPairGen.initialize(1024);
			KeyPair keyPair = keyPairGen.generateKeyPair();
			PrivateKey privateKey = keyPair.getPrivate();
			PublicKey publicKey = keyPair.getPublic();
			System.out.println(privateKey.getAlgorithm());
			System.out.println(privateKey.getFormat());
			System.out.println(toText(privateKey.getEncoded()));
			System.out.println(publicKey.getAlgorithm());
			System.out.println(publicKey.getFormat());
			System.out.println(toText(publicKey.getEncoded()));
			System.out.println(new BASE64Encoder().encode(publicKey.getEncoded()));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static String toText(byte[] bytes) {
		StringBuilder builder = new StringBuilder();
		builder.append(bytes[0]);
		for (int i = 1; i < bytes.length; i++) {
			builder.append(',');
			builder.append(bytes[i]);
		}
		return builder.toString();
	}
}