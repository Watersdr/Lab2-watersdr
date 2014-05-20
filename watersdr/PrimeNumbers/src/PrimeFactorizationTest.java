import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import java.util.ArrayList;

import org.junit.Test;


/**
 * TODO Put here a description of what this class does.
 *
 * @author watersdr.
 *         Created Mar 25, 2014.
 */
public class PrimeFactorizationTest {
	
	@Test
	public void testOne() {
		assertEquals(makeList(), PrimeNumber.getPrimeFactors(1));
	}
	
	@Test
	public void testTwo() {
		assertEquals(makeList(2), PrimeNumber.getPrimeFactors(2));
	}
	
	@Test
	public void testThree() {
		assertEquals(makeList(3), PrimeNumber.getPrimeFactors(3));
	}
	
	@Test
	public void testFour() {
		assertEquals(makeList(2, 2), PrimeNumber.getPrimeFactors(4));
	}
	
	@Test
	public void testFive() {
		assertEquals(makeList(5), PrimeNumber.getPrimeFactors(5));
	}
	
	@Test
	public void testSix() {
		assertEquals(makeList(2, 3), PrimeNumber.getPrimeFactors(6));
	}
	
	@Test
	public void testTwelve() {
		assertEquals(makeList(2, 2, 3), PrimeNumber.getPrimeFactors(12));
	}
	
	@Test
	public void testBigAssNumber() {
		assertEquals(makeList(5, 7, 7, 1327), PrimeNumber.getPrimeFactors(325115));
	}
	
	public ArrayList<Integer> makeList(int...ints) {
		ArrayList<Integer> result = new ArrayList<Integer>();
		for (int i : ints) {
			result.add(i);
		}
		return result;
	}

}
