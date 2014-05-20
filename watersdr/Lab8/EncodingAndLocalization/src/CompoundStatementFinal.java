import java.text.MessageFormat;
import java.util.*;




public class CompoundStatementFinal {

	public static void main(String[] args) {
		
		Locale currentLocale = new Locale("fr", "FR");
		ResourceBundle messages = ResourceBundle.getBundle("MessagesBundle", currentLocale);
		String template = messages.getString("template");
		
		
		Object[] messageArguments = {
			    "Mars",
			    new Integer(7),
			    new Date()
		};
		
		MessageFormat formatter = new MessageFormat("");
		formatter.setLocale(currentLocale);
		formatter.applyPattern(template);
		System.out.println(formatter.format(messageArguments));
	}

}
