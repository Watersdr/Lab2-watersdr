import java.util.ArrayList;


/**
 * TODO Put here a description of what this class does.
 *
 * @author watersdr.
 *         Created Mar 25, 2014.
 */
public class PrimeNumber {

	/**
	 * TODO Put here a description of what this method does.
	 *
	 * @param i
	 * @return
	 */
	public static ArrayList<Integer> getPrimeFactors(int n) {
		ArrayList<Integer> result = new ArrayList<Integer>();
		int currentCandidate = 2;
		int num = n;
		while (num > 1) {
			if (num % currentCandidate == 0) {
				num = num/currentCandidate;
				result.add(currentCandidate);
			}
			else {
				currentCandidate++;
			}
		}
		return result;
	}

}
