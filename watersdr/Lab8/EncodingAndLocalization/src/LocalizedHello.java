import java.util.*;

public class LocalizedHello {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Locale currentLocale;
        ResourceBundle messages;

        currentLocale = new Locale("jp", "JP");

        messages = ResourceBundle.getBundle("MessagesBundle", currentLocale);
        System.out.println(messages.getString("hello"));
        System.out.println(messages.getString("goodbye"));
        System.out.println(messages.getString("how_are_you"));
	}
}
