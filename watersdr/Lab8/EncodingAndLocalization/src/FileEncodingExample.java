import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

/**
 * 
 */

/**
 * TODO You need to make sure your output is set to UTF-8 for this to work
 * Note that not all characters are displayed, at least as far as I can tell
 *
 * @author hewner.
 *         Created Apr 16, 2014.
 */
public class FileEncodingExample {
	public static void main(String[] args) throws IOException {
		
		BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream("example2.txt"), "Shift_JIS"));
		
		String line = reader.readLine();
		while(line != null) {
			
			
		
			System.out.println(line);
			line = reader.readLine();
		}
		reader.close();
	}
}
