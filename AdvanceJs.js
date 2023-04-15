/* Function to add two values and return the result
    param x: Augend
    param y: Addend
    return: The sum
 */
function add(x, y) {
    return x + y;
}

/* Function to subtract second value from the 
    first, and return the result
    param x: Minuend
    param y: Subtrahend
    return: The difference
 */
function subtract(x, y) {
    return x - y;
}

/* Function to multiply two values and return the result
    param x: Multiplier
    param y: Multiplicand
    return: The product
 */
function multiply(x, y) {
    return x * y;
}


/* Function to check if division is safe and returns the result afterwards    
    param x: Numerator
    param y: Denominator, excluding 0
    return: the result from division, if condition is NOT satisfied
            throw an exception with an error message, if condition is satisfied
    datatype of returned result will be the same as the type 
    of passed arguments
 */
function divide(x, y) {
    if (y == 0) {
        throw 'You tried dividing by 0. Re-compile and try different denominator';
    }
    else return x / y;
}

// Function to calculate the remainder from division of two numbers
function calculateRemainder(x, y) {
    return x % y;
}

// Function to calculate an exponential term and return the resuslt
function calculateExponentiation(x, n) {
    if (n < 0) {
        console.log("Valid exponent required. ");
        return -1;
    }
    result = 1;
    for (i = 1; i <= n; i++) {
        result *= x;
    }
    return result;
}

// Function to calculate and return the square root of a number
function calculateSquareRoot(x) {
    return Math.sqrt(x);
}


// Function to display all possible operations calculator supports
// Added to avoid any unnecessary prints in future
function displayOptions() {
    console.log("Available operations: \n" +
        "\t+ | Addition\n" +
        "\t- | Subtraction\n" +
        "\t/ | Division\n" +
        "\t* | Multiplication\n" +
        "\t% | Remainder\n" +
        "\t^ | Exponentination\n" +
        "\ts | Square root\n");
}

function displayMessage() {
    console.log("UPDATE: ");
    console.log("All results are marked with letter 'R' in front of them.\n"
        + "Numbers that have asterix symbol (*) are the ones selected from the list.\n"
        + "Numbers that are selected from the list always behave as first operands.\n"
        + "Program will ask user for another input if number at certain index in the list \n"
        + "cannot be found. Program will ask for the valid index entry.\n");
}

function printListElements(elements) {
    for (let i = 0; i < elements.length; i++) {
      console.log(elements[i]);
    }
  }

function containsOnlyNumbers(str) {
    return /-?\d+(\.\d+)?(e[+-]?\d+)?/g.test(str);
}


// *** Testing ***

var num, num1, num2, result = 0,
    amendNum = 0,
    operation = "e",
    breaker = "default",
    esc = true,
    temp = 0,
    passedValue = 0
    extractedNumber = "default",
    controller = false,
    listIndex = 0,
    convertedResult = 0;

// store saved elements
const elements = [];
/*  
 *  prompt-sync node.js packages installed through Windows PowerShell
 *  to enable user input in terminal window in VS Code.
 *  Plugin obtained from: https://www.npmjs.com/package/prompt-sync
 *  Code runs on a local machine, but plugin might need to be installed before
 *  running the script elsewhere.
 */
const prompt = require("prompt-sync")();

displayMessage();
displayOptions();
console.log("Enter the number, then select your operation, and enter the second number followed by '=' ");

/**
 * program loops until esc obtains 'false' value
 * esc becomes 'false' if user tries to terminate 
 * the program using either q or Q key within either
 * loop.
 */
while (esc) {
    /**
     * Checks if user decided to enter two new numbers
     * within the nested loop. Skips the input, temp variable 
     * 'num' from nested loop is assigned to num1.
     */

    if (containsOnlyNumbers(breaker)) {
        num1 = num;
        breaker = "default";
    }
    else {
        while (true) {
            try {
                num1 = parseFloat(prompt());
                break;
            } catch (error) {
                console.log("");
            }
        }
    }

    // Keeps asking for valid operation. When valid entry is detected, loop breaks and further execution continues
    while (true) {
        operation = prompt();
        if (operation == "+" || operation == "-" || operation == "/" ||
            operation == "*" || operation == "%" || operation == "^" || operation == "s" ||
            operation == "q" || operation == "Q" || operation == "P")
            break;
    }

    // If any exception is thrown during an execution of a try block, loop resets
    // If a valid entry is detected, break statement in try block exits the loop and continues with further execution
    while (true) {
        try {    
            switch (operation) {
                case "+":
                    num2 = parseFloat(prompt());
                    result = add(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {                            
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "-":
                    num2 = parseFloat(prompt());
                    result = subtract(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "/":
                    num2 = parseFloat(prompt());
                    result = divide(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "*":
                    num2 = parseFloat(prompt());
                    result = multiply(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "%":
                    num2 = parseFloat(prompt());
                    result = calculateRemainder(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "^":
                    num2 = parseFloat(prompt());
                    result = calculateExponentiation(num1, num2).toFixed(1);
                    while (true) {
                        operation = prompt();
                        if (operation == "=" || operation == "") {
                            console.log("R: " + result);
                            break;
                        }
                        else if (operation == "M") {
                            elements.push(num2);
                            console.log(" -> " + num2 + " added to list.");
                            operation = prompt();
                            if (operation == "=" || operation == "") {
                                console.log("R: " + result);
                                break;
                            }
                        }
                        else
                            continue;
                    }
                    break;
                case "s":
                    if (result == 0) {
                        result = calculateSquareRoot(num1).toFixed(1);
                    }
                    else {
                        result = calculateSquareRoot(result).toFixed(1);
                    }
                    while (true) {                        
                        operation = prompt();
                        if (operation == "=" || operation == "") {                            
                            console.log("R: " + result);
                            break;
                        }
                    }
                    break;
                case "q":
                    esc = false;
                    break;
                case "Q":
                    esc = false;
                    break;
                default:
                    console.log("Wrong operation!");
                    break;
            }
            break;
        } catch (error) {
            console.log("");
        }
    }



    // DECIDER SEQUENCE BEGINS
    // Checks if user keeps appending operations
    // If user input is a number, the program will store the value in the temporary variable 'num' 
    // and assign that value to a first number in an outer loop. Otherwise, if a valid operation 
    // is detected, program asks for another input, which will be appended to the previous 
    // result, depending on which operation user chose.

    // UPDATE 
    // When a number is selected from the list of saved elements, it will be marked 
    // with asterix symbol (*). This is to keep the interface as clean as possible
    while (!containsOnlyNumbers(breaker) && esc) {
        breaker = prompt()

        if (breaker == "+" || breaker == "-" || breaker == "/" || breaker == "*"
            || breaker == "%" || breaker == "^" || breaker == "s") {
            while (true) {
                try {
                    switch (breaker) {
                        case "+":
                            amendNum = parseFloat(prompt());                            
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = add(parseFloat(result), amendNum).toFixed(1);                                
                                controller = false;
                            }
                            else {
                                result = add(parseFloat(result), amendNum).toFixed(1);                                                            
                            }
                            break;
                        case "-":
                            amendNum = parseFloat(prompt());
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = subtract(parseFloat(result), amendNum).toFixed(1);
                                controller = false;
                            }
                            else {
                                result = subtract(parseFloat(result), amendNum).toFixed(1);
                            }                            
                            break;
                        case "/":
                            amendNum = parseFloat(prompt());
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = divide(parseFloat(result), amendNum).toFixed(1);
                                controller = false;
                            }
                            else {
                                result = divide(parseFloat(result), amendNum).toFixed(1);
                            }                            
                            break;
                        case "*":
                            amendNum = parseFloat(prompt());
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = multiply(parseFloat(result), amendNum).toFixed(1);
                                controller = false;
                            }
                            else {
                                result = multiply(parseFloat(result), amendNum).toFixed(1);
                            }
                            break;
                        case "%":
                            amendNum = parseFloat(prompt());
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = calculateRemainder(parseFloat(result), amendNum).toFixed(1);
                                controller = false;
                            }
                            else {
                                result = calculateRemainder(parseFloat(result), amendNum).toFixed(1);
                            }
                            break;
                        case "^":
                            amendNum = parseFloat(prompt());
                            temp = amendNum;
                            if(controller) {
                                result = passedValue;
                                result = calculateExponentiation(parseFloat(result), amendNum).toFixed(1);
                                controller = false;
                            }
                            else {
                                result = calculateExponentiation(parseFloat(result), amendNum).toFixed(1);
                            }
                            break;
                        case "s":
                            if(controller) {
                                result = calculateSquareRoot(passedValue).toFixed(1);
                                controller = false;
                            }
                            else if (result == 0) {
                                result = calculateSquareRoot(num1).toFixed(1);
                            }
                            else {
                                result = calculateSquareRoot(result).toFixed(1);
                            }
                            break;
                        default:
                            console.log("There has been an error.");
                            break;
                    }
                    break;
                } catch (error) {
                    console.log("");
                }
            }

            while (true) {
                operation = prompt();
                if (operation == "=" || operation == "") {
                    // console.log(typeof(result));
                    console.log("R: " + result);
                    break;
                }
                else if (operation == "M") {
                    elements.push(temp);
                    console.log(" -> " + temp + " added to list.");
                    operation = prompt();
                    if (operation == "=" || operation == "") {
                        console.log("R: " + result);
                        break;
                    }
                }
            }
        }
        else if (containsOnlyNumbers(breaker) && !breaker.includes('R')) {
            num = parseFloat(breaker); // If a number in string is detected, converts it to float.
            continue;
        }
        else if (breaker == "q" || breaker == "Q") {
            elements.splice(0);
            esc = false;
            break;
        }
        else if (breaker == "M") {
            elements.push(result);
            console.log(" -> " + result + " added to list.");
            continue;
        }
        else if (breaker == "P") {
            console.log("Saved elements: ");
            printListElements(elements);
            console.log("");
            continue;
        }
        else if (breaker.includes('R')) {
            extractedNumber = breaker.match(/-?\d+(\.\d+)?(e[+-]?\d+)?/g);
            listIndex = parseFloat(extractedNumber[0]);            
            if(elements.length > 0 && !isNaN(elements[listIndex-1])) { // check this condition
                console.log(elements[listIndex-1] + "(*)");
                passedValue = elements[listIndex-1];
                controller = true;
            }
            else {
                console.log("Result does not exist at location. ");
                while (true) {
                    breaker = prompt();
                    if(breaker.includes('R')) {
                        extractedNumber = breaker.match(/-?\d+(\.\d+)?(e[+-]?\d+)?/g);
                        listIndex = parseFloat(extractedNumber[0]);
                        if(elements.length > 0 && !isNaN(elements[listIndex-1])) {
                            console.log(elements[listIndex-1] + "(*)");
                            passedValue = elements[listIndex-1];
                            controller = true;
                            break;
                        }
                    }
                }
            }
            breaker = "default";
        }
        else
            continue;
    }
}