import static org.junit.Assert.*;

import java.text.MessageFormat;
import java.util.Date;
import java.util.Locale;
import java.util.ResourceBundle;

import org.junit.Test;

public class PrintBalanceTest
{
	
	@Test
	public void Germantest()
	{
		Locale currentLocale = new Locale("de", "DE");
		PrintBalance test = new PrintBalance(currentLocale, "Jimmy");
		Date today = new Date();
		ResourceBundle messages = ResourceBundle.getBundle("DateForTest");
		Object[] messageArgs = {
				today,
			};
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(currentLocale);
		formatter.applyPattern(messages.getString("date"));
		
		assertEquals(test.getPrintBalanceString(), "Hallo Welt\nBitte geben Sie Ihren Namen Jimmy\nIch freue mich, Sie zu treffen Jimmy. Ab "
				+ formatter.format(messageArgs) + ", Sie verdanken die Schule 7.125.933,05 Euros.\n Auf Wiedersehen.");
	}
	
	@Test
	public void Frenchtest()
	{
		Locale currentLocale = new Locale("fr", "FR");
		PrintBalance test = new PrintBalance(currentLocale, "Jimmy");
		Date today = new Date();
		ResourceBundle messages = ResourceBundle.getBundle("DateForTest");
		Object[] messageArgs = {
				today,
			};
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(currentLocale);
		formatter.applyPattern(messages.getString("date"));
		
		assertEquals(test.getPrintBalanceString(), "Bonjour tout le monde.\nS'il vous plaît entrer votre nomJimmy\nJe suis heureux de vous rencontrer Jimmy. En date du "
				+ formatter.format(messageArgs) + ", Vous devez lécole 7.125.933,05 Euros.\n Au revoir.");
	}
	
	@Test
	public void Englishtest()
	{
		Locale currentLocale = new Locale("en", "US");
		PrintBalance test = new PrintBalance(currentLocale, "Jimmy");
		Date today = new Date();
		ResourceBundle messages = ResourceBundle.getBundle("DateForTest");
		Object[] messageArgs = {
				today,
			};
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(currentLocale);
		formatter.applyPattern(messages.getString("date"));
		
		assertEquals(test.getPrintBalanceString(), "Hello World\nPlease enter your nameJimmy\nI am pleased to meet you Jimmy. As of : "
				+ formatter.format(messageArgs) + ", You owe the school $9876543.21\n Good Bye");
	}
	
}
