# Python Calculator
import sys
import math
import re


def add(x, y):
    """
    add function adds two values passed as
    arguments together and returns the result
    :param x: addend
    :param y: addend
    :return: the sum
    """
    pass
    return x + y


def subtract(x, y):
    """
    subtract function subtracts the value of second argument
    from the value of the first argument and returns the result
    :param x: minuend
    :param y: subtrahend
    :return: difference
    """
    pass
    return x - y


def multiply(x, y):
    """
    multiply function multiplies the two values passed as an
    argument and returns the result
    :param x: multiplier
    :param y: multiplicand
    :return: product
    """
    pass
    return x * y


def divide(x, y):
    """
    divides two numbers and returns the result
    :param x: dividend
    :param y: divisor
    :return: quotient
    If 0 is passed as a divisor, program will exit
    """
    pass
    if y == 0:
        sys.exit("You tried dividing by zero. Interpret to try again")
    else:
        return x / y


def calculate_remainder(x, y):
    return x % y


def calculate_exponentiation(x, n):
    if n < 0:
        print("Exponent must be a non-negative integer.")
        sys.exit(1)
    else:
        i = n - 1
        res = x
        while i > 0:
            res = res * x
            i = i - 1
        return res


def calculate_square_root(x):
    return math.sqrt(x)


def display_message():
    print("UPDATE: \n"
          + "All results are marked with letter 'R' in front of them. \n"
          + "Numbers that have asterix symbol (*) are the ones selected from the list. \n"
          + "Numbers that are selected from the list always behave as the first operands. \n"
          + "Program will ask user for another input if number at certain index in the list \n"
          + "cannot be found. Program will ask for the valid index entry. \n")


# *** TESTING THE PROGRAM ***


num = 0.0
num1 = 0.0
num2 = 0.0
result = 0.0
temp = 0.0
passedValue = 0.0
amend_num = 0.0
operation = 'd'
breaker = "default"
extractedNumber = "default"
escape = True
controller = False
listIndex = 0

elements = []

display_message()
print("Available operations: \n" +
      "\t+ | Addition\n" +
      "\t- | Subtraction\n" +
      "\t/ | Division\n" +
      "\t* | Multiplication\n" +
      "\t% | Remainder\n" +
      "\t^ | Exponentiation\n" +
      "\ts | Square root\n")

print("Enter the number, then select your operation, and enter the second number followed by '=': ")

# escape will be true until one of the loops detects 'q' or 'Q' as an operation
while escape:
    if breaker.isdigit() or breaker.lstrip("-").isdigit():
        # assigning the value from the nested loop to num1
        num1 = num
        breaker = "default"
    else:
        # if user entered operator in nested loop, provide input
        while True:
            try:
                num1 = float(input(""))
                break
            except Exception:  # NOQA
                print("")

    while True:
        operation = input()
        if operation == "+" or operation == "-" or operation == "/" or operation == "*" \
                or operation == "%" or operation == "^" or operation == "s" or operation == "q" \
                or operation == "Q" or operation == "P":
            break

    while True:
        try:
            if operation == "+":
                num2 = float(input(""))
                result = round(add(num1, num2), 1)  # rounding the result to 1 decimal
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "-":
                num2 = float(input(""))
                result = round(subtract(num1, num2), 1)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "/":
                num2 = float(input(""))
                result = round(divide(num1, num2), 1)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "*":
                num2 = float(input(""))
                result = round(multiply(num1, num2), 1)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "%":
                num2 = float(input(""))
                result = round(calculate_remainder(num1, num2), 1)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "^":
                num2 = int(input(""))
                result = round(calculate_exponentiation(num1, num2), 1)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
                    elif operation == "M":
                        elements.append(num2)
                        print(" -> ", num2, " added to list.")
                        operation = input()
                        if operation == "=" or operation == "":
                            print("R: ", result)
                            break
                    else:
                        continue
            elif operation == "s":
                if result == 0:
                    result = round(calculate_square_root(num1), 2)
                else:
                    result = round(calculate_square_root(result), 2)
                while True:
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break
            elif operation == "q" or operation == "Q":
                escape = False
                break
            else:
                print("Error")
                sys.exit(1)
            break  # this is the break from try, needs to be deleted later on
        except Exception: # NOQA
            print()

    # UPDATE
    # When a number is selected from the list of saved elements, it will be marked
    # with asterix symbol (*). This is to keep the interface as clean as possible
    # block which checks if the input after the 1st result is operation or a new number
    while not breaker.isdigit() or breaker.lstrip("-").isdigit():
        breaker = input()  # breaker is string, number is extracted and assigned to num
        # if it's detected among string characters

        if breaker == "+" or breaker == "-" or breaker == "/" or breaker == "*" or breaker == "%" or breaker == "^" or \
                breaker == "s":
            while True:
                try:
                    if breaker == "+":
                        amend_num = float(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(add(result, amend_num), 1)
                            controller = False
                        else:
                            result = round(add(result, amend_num), 1)
                    elif breaker == "-":
                        amend_num = float(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(subtract(result, amend_num), 1)
                            controller = False
                        else:
                            result = round(subtract(result, amend_num), 1)
                    elif breaker == "/":
                        amend_num = float(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(divide(result, amend_num), 1)
                            controller = False
                        else:
                            result = round(divide(result, amend_num), 1)
                    elif breaker == "*":
                        amend_num = float(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(multiply(result, amend_num), 1)
                            controller = False
                        else:
                            result = round(multiply(result, amend_num), 1)
                    elif breaker == "%":
                        amend_num = float(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(calculate_remainder(result, amend_num), 1)
                            controller = False
                        else:
                            result = round(calculate_remainder(result, amend_num), 1)
                    elif breaker == "^":
                        amend_num = int(input())
                        temp = amend_num
                        if controller:
                            result = passedValue
                            result = round(calculate_exponentiation(result, amend_num), 1)
                    elif breaker == "s":
                        if controller:
                            result = round(calculate_square_root(passedValue), 2)
                            controller = False
                        elif result == 0:
                            result = round(calculate_square_root(num1), 2)
                        else:
                            result = round(calculate_square_root(result), 2)
                    else:
                        print("Error. 2nd case")
                        sys.exit(1)
                    break
                except Exception:  # NOQA
                    print("")

            while True:
                operation = input()
                if operation == "=" or operation == "":
                    print("R: ", result)
                    break
                elif operation == "M":
                    elements.append(temp)
                    print(" -> ", temp, " added to list.")
                    operation = input()
                    if operation == "=" or operation == "":
                        print("R: ", result)
                        break

        # checks if there is a valid number in string, extract it, and store in num
        elif re.findall(r'[-+]?\d+', breaker) and breaker.find("R") == -1: # if error happens check the condition
            li = re.findall(r'[-+]?\d+', breaker)
            num = float(li[0])
            continue
        elif breaker == "q" or breaker == "Q":
            elements.clear()
            escape = False
            break
        elif breaker == "M":
            elements.append(result)
            print(" -> ", result, " added to list. ")
            continue
        elif breaker == "P":
            print("Saved elements: ")
            print(elements, "\n")
            continue
        elif "R" in breaker:
            extractedNumber = re.findall(r'[-+]?\d+', breaker)
            listIndex = int(extractedNumber[0])
            if len(elements) > 0 and listIndex-1 < len(elements):
                print(elements[listIndex-1], "(*)")
                passedValue = elements[listIndex-1]
                controller = True
            else:
                print("Result does not exist at location")
                while True:
                    breaker = input()
                    if "R" in breaker:
                        extractedNumber = re.findall(r'[-+]?\d+', breaker)
                        listIndex = int(extractedNumber[0])
                        if len(elements) > 0 and listIndex-1 < len(elements):
                            print(elements[listIndex-1], "(*)")
                            passedValue = elements[listIndex-1]
                            controller = True
                            break
            breaker = "default"
        else:
            continue
