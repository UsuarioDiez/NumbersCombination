This program reads a N sized array of ints and checks how many combinations give as sum the max value of the array.

The steps are:

1. Read how many items your array will have.
2. Read the array items.
3. Identify the array's max value and change it to 0 (first occurence) so we can discard that value in the following calcules.
4. Create an array of binary numbers mapping each different combination of values we can take from the original array, being 0 a deactivated value an 1 a selected value. So an array can have 2^n-1 different combinations of values.
For instance, the array:(1,3,5,2) can have 15 different combinations being the count from 1 to 15 in binary.

| Decimal | Binary | Combination |
|---------|--------|-------------|
| 1 | 0001 | 2 |
| 2 | 0010 | 5 |
| 3 | 0011 | 5,2 |
| 4 | 0100 | 3 |
| 5 | 0101 | 3,2 |
| 6 | 0110 | 3,5 |
| 7 | 0111 | 3,5,2 |
| 8 | 1000 | 1 |
| 9 | 1001 | 1,2 |
| 10 | 1010 | 1,5 |
| 11 | 1011 | 1,5,2 |
| 12 | 1100 | 1,3 |
| 13 | 1101 | 1,3,2 |
| 14 | 1110 | 1,3,5 |
| 15 | 1111 | 1,3,5,2 |

5. Loop throught each binary number in the binary numbers array and take the sum of original array's values whose position maps an 1 in the binary number.
6. Count succesful combinations and show them on screen.
