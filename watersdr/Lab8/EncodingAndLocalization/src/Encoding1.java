import java.util.Arrays;


public class Encoding1 {


	public static void outputString(String s)
	{
		System.out.println(s);
		System.out.println(Arrays.toString(s.toCharArray()));
		System.out.println(Arrays.toString(s.getBytes()));		
	}
	
	public static void main(String[] args) {
		String s1 = "忍 者";
		String s2 = "ninja";
		outputString(s1);
		outputString(s2);
	}

}
