# Merged Sorted Arrays Algo

- The first thing I did was intitialize two pointers, ``pointerOne`` and ``pointerTwo`` that will be used to access the values of ``arrOne`` and ``arrTwo`` at each index
- The ``int[] result`` array, which will be the value we will be returning, is then initialized to a length that is a combination of the length of the two arrays we will be merging
- We know the amount of times we will need to iterate since we just initialzied what we know the length of ``result`` to be therefore we can use a for loop
## The first two conditions
```csharp
if (pointerOne >= arrOne.Length)
{
    result[i] = arrTwo[pointerTwo++];
}
else if (pointerTwo >= arrTwo.Length)
{
    result[i] = arrOne[pointerOne++];
}
```
- In some other languages, this would not be an issue but in C#, if we try to access an index that does not exist in array, we will get an error. Therefore, once our pointer value is over the length of the associated array, we want to only start adding the rest of the other array to our ``result`` array.

## The last condition:
```csharp
else
{
    result[i] = arrOne[pointerOne] < arrTwo[pointerTwo] ? arrOne[pointerOne++] : arrTwo[pointerTwo++];
}
```
- This condition is hit when neither ``pointerOne`` or ``pointerTwo`` is greater than their associated array's length. We then can compare the values at each array, starting at index 0. I used a ternary operator to determine what result[i] would be in order to limit the code used. Once compared, the lesser value will be set to result[i] and then that pointer incremented. 
- Once the for loop is complete, the result array is then returned. 