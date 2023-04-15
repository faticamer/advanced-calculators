# Advanced Console Calculators
Console calculator in 3 different languages, Python, JavaScript, and C#. 

Basic calculator functions implemented in Python, JavaScript and C#. 

Calculator consists of addition, subtraction, multiplication, division, exponentiation, root and finally, remainder calculation.

Each operation only applies to maximum of 2 numbers, with an exception of square root that only accepts one number. Input is the same in each language, where new line is required for every operation/number. 

Scripts are tolerant on wrong inputs, meaning that the program will not stop running until right input is detected. This applies to both operations and numbers. 

When first operation is performed, the program will not ask user for new operation/number. Instead, program will wait for an input which can be both operation or a number, and then proceed with an execution. Wrong input tolerance is implemented in this part as well.

Added feature to save the result. Added functionality of selecting any saved result, where user can continue performing operations on a selected number.

Hotkeys:
M - Add a result to a list
P - Show all saved elements in the list
Rn - Select a number, where n is a positive integer that corresponds to an index in a list
Q - Terminate the program
