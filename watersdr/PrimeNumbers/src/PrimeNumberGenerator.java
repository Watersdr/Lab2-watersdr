import java.util.ArrayList;


/**
 * TODO Put here a description of what this class does.
 *
 * @author watersdr.
 *         Created Mar 26, 2014.
 */
public class PrimeNumberGenerator {

	/**
	 * TODO Put here a description of what this method does.
	 *
	 * @param i
	 * @return
	 */
	public static ArrayList<Integer> getPrimes(int num) {
		ArrayList<Integer> result = new ArrayList<Integer>();
		if (num < 2) return result;
		for (int i = 2; i < num; i++) {
			if (isPrime(i)) {
				result.add(i);
			}
		}
		return result;
	}

	/**
	 * TODO Put here a description of what this method does.
	 *
	 * @param i
	 * @return
	 */
	private static boolean isPrime(int num) {
		if (num < 2) return false;
		for (int i = 2; i*i <= num; i++) {
			if (num % i == 0) return false;
		}
		return true;
	}
}
