import java.text.MessageFormat;
import java.util.*;




public class CompoundStatement {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		Locale currentLocale = new Locale("de", "DE");
		ResourceBundle message = ResourceBundle.getBundle("MessagesBundle", currentLocale);
		String template = message.getString("template");
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
