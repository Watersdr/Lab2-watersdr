import java.io.UnsupportedEncodingException;
import java.io.UnsupportedEncodingException;
import java.util.Arrays;


public class Encoding2 {


	public static void outputString(String s)
	{
		System.out.println(s);
		System.out.println(Arrays.toString(s.toCharArray()));
		System.out.println(Arrays.toString(s.getBytes()));		
	}
	
	public static void main(String[] args) {
		String s1 = "ninja - 忍者";
		byte[] bytes = s1.getBytes();
		String[] encodings = { "Cp1252", "UTF-8", "Cp850","Cp862","ISO8859_1","Cp874"};
		for(String encoding : encodings) {
			String s;
			try {
				s = new String(bytes, encoding);
				System.out.println(s);
			} catch (UnsupportedEncodingException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
		}
	}

}
