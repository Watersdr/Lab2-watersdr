import java.text.MessageFormat;
import java.util.Date;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.Scanner;


/**
 * TODO A simple class that needs to be localized
 *
 * @author mohan.
 *         Created Mar 27, 2011.
 */
public class PrintBalance{

	private Locale locale;
	private String name;
	
	/**
	 * Simple Java Method that is crying out to be localized.
	 *
	 * @param args
	 */
	
	public PrintBalance(Locale locale, String name)
	{
		this.locale = locale;
		this.name = name;
	}
	
	public String getPrintBalanceString()
	{
		String result;
		
		ResourceBundle messages = ResourceBundle.getBundle("MyMessagesBundle", this.locale);
		String template = messages.getString("second_part");
		Date today = new Date();
		result = messages.getString("hello") + "\n" + messages.getString("enter_name") + this.name + "\n";
		
		Object[] messageArgs = {
				today,
				this.name
			};
		
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(this.locale);
		formatter.applyPattern(template);
		result += messages.getString("first_part") + this.name + ". ";
		result += formatter.format(messageArgs);
		
		
		return result;
	}
	public static void main(String args[])
	{
		Locale currentLocale = new Locale("fr", "FR");
		ResourceBundle messages = ResourceBundle.getBundle("MyMessagesBundle", currentLocale);
		String template = messages.getString("second_part");
		
		Scanner scanInput = new Scanner(System.in);
		Date today = new Date();
		
		//Greeting
		System.out.println(messages.getString("hello"));
		
		//Get User's Name
		System.out.println(messages.getString("enter_name"));
		String name = scanInput.nextLine();
		Object[] messageArgs = {
			today,
			name
		};
		
//		System.out.println("I am pleased to meet you " + name);
		
		//print today's date, balance and bid goodbye
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(currentLocale);
		formatter.applyPattern(template);
		System.out.print(messages.getString("first_part") + name + ". ");
		System.out.println(formatter.format(messageArgs));
//		System.out.println("As of : "+ today.toString());
//		System.out.println("You owe the school $9876543.21");
//		System.out.println("Good Bye");
	}
}



