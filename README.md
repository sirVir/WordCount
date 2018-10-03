# WordCount
A sample C# program to list and count all the words in the input text file.

## Assumptions
The resulting collection can be held in-memory. As the file is read from a text file, it means that in pessimistic case (all text in one word or no repetition), the stored structure would be at least as large.
The order of returned word counts is not guaranteed.
Word count does not exceed Int32.
Input is already validated and consists of parsable characters.

## Solutions
Input file is lazily loaded to avoid input file size constraints. Focus is on the sparsity and code readability, no meaningful error handling included.

### DictionaryBackedWordCounter
A quick LINQ implementation based on the built-in C# dictionary of strings and integers. Since both insertion and retrieval operations in C# dictionary take O(1), the total complexity of the solution is O(n). Notes: Expansion of C# Dictionary is an expensive operation, which might influence the declared complexity in some cases. No guarantee of returned word order is preserved in Dictionary, but OrderedDictionary could be used if needed. Words are split using whiteline characters, as defined in documentation

### TrieBasedWordCounter
An implementation based on prefix tree. Prefix tree is a data structure, which is often used as an example of efficient text indexing (search always with guaranteed time of access of key length), but in this case might be used to store the word count. It is constructed lineary from the input time in O(n). Tree traversal, which is effectively listing all the stored words is also performed in O(n) in respect to the number of unique words (tree is traversed recuresively). As a side node, such a tree returns all the words sorted when traversed pre-order, which might be an additional benefit.

For the trie implementation some additional assumptions were made for simplicity. Captialization of the words is insignifficant (as in example, "Go" and "go" is considered to be the same word). Alphabet was reduced to ASCII English 26-characters, so efficient, array-based trie implementation could be approached without too mutch character mapping (indexes offset by letter sign used).

Another tree-based structure called Deterministic Acyclic finite state automateon (https://en.wikipedia.org/wiki/Deterministic_acyclic_finite_state_automaton) could be used for implementing the task, reducing the memory requirements (since it doesn't have to store )