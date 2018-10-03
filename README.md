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
A quick LINQ implementation based on the built-in C# dictionary of strings and integers. Both insertion and retrieval operations in C# dictionary have amorthized cost of O(1). No guarantee of returned word order is preserved in Dictionary, but OrderedDictionary could be used if needed - with the tradeoff of increased memory storage and complexity of "Add" operations. Words are split using whiteline characters, as defined in documentation

### TrieBasedWordCounter
An implementation based on prefix tree. Prefix tree is a data structure which is often used as an example of efficient text indexing (search always with guaranteed time of access of key length), but in this case might be used to store the word count. It is constructed lineary from the input, each add operation is guaranteed ot be O(1). Retrieval from value is also O(1). The solution does not use hashes, which can be seen as a benefi. Tree traversal, which is effectively listing all the stored words is also performed in O(m) in respect to the number of unique words (tree is traversed recuresively). As a side node, such a tree returns all the words in alphabetical order when traversed pre-order, which might be an additional benefit.

To simplify the trie implementation any sequence of English alphabet is considered to be a word. Captialization of the words is insignifficant. Thanks to that, an efficient, array-based trie implementation could be approached without a complex character mapping.

### Other possible solutions
Another tree-based structure called Deterministic Acyclic finite state automateon (https://en.wikipedia.org/wiki/Deterministic_acyclic_finite_state_automaton) could be used for implementing the task, reducing the memory requirements (since it doesn't have to store the duplicated prefixes). It would, hovewer require some modifications, because it does not allow to directly associate extra data with word termination. 