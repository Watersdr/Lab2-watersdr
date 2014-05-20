import static org.junit.Assert.*;

import java.util.ArrayList;

import org.junit.Test;


/**
 * TODO Put here a description of what this class does.
 *
 * @author watersdr.
 *         Created Mar 26, 2014.
 */
public class PrimeNumberGeneratorTest {

	@Test
	public void testOne() {
		assertEquals(makeList(), PrimeNumberGenerator.getPrimes(1));
	}
	
	@Test
	public void testTwo() {
		assertEquals(makeList(), PrimeNumberGenerator.getPrimes(2));
	}
	
	@Test
	public void testThree() {
		assertEquals(makeList(2), PrimeNumberGenerator.getPrimes(3));
	}
	
	@Test
	public void testFour() {
		assertEquals(makeList(2, 3), PrimeNumberGenerator.getPrimes(4));
	}
	
	@Test
	public void testFive() {
		assertEquals(makeList(2, 3), PrimeNumberGenerator.getPrimes(5));
	}

	@Test
	public void testThirtteen() {
		assertEquals(makeList(2, 3, 5, 7, 11), PrimeNumberGenerator.getPrimes(13));
	}
	
	@Test
	public void test50() {
		assertEquals(makeList(2,3,5,7,11,13,17,19,23,29,31,37,41,43,47), PrimeNumberGenerator.getPrimes(50));
	}
	
	public ArrayList<Integer> makeList(int...ints) {
		ArrayList<Integer> result = new ArrayList<Integer>();
		for (int i : ints) {
			result.add(i);
		}
		return result;
	}

}
