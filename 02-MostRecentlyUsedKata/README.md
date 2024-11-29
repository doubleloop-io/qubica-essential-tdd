
## Description
We are developing an editor and one of the features is to show a list of recently opened files. Your task is to write a software component in TDD.

The features are:
- We need to be able to add an element to it (keep it in memory).
- We need to be able to get the list of elements added.
- We need a way to access the elements so that a UI component can render them.
- Elements retrieved must be in a LIFO order.
- If I add an element to the list which is already present, it's moved to the top instead of adding a duplicate.
- The number of elements is capped (we think 10 is enough).

### TODO (aka test list)
- What's the first test?
