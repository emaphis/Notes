
/// Functional programming languages elevate functions to first class values.
/// - You can bind functions to identifiers.
/// - You can store function in data structures such as lists.
/// - You can pass a function as an arguement in a function call.
/// - You can return a function from a function call


/// Give the Value a Name

/// If a function is a first-class value, you must be able to name it, just as you can name
/// integers, strings, and other built-in types. This is referred to in functional programming
/// literature as binding an identifier to a value. F# uses 'let' bindings to bind names to
/// values: 'let <identifier> = <value>'. The following code shows two examples.

module NameFunctions =

    /// Integer and string.
    let num = 10
    let str = "F#"

    /// You can name a function just as easily.  The following example defines a function named
    /// 'squareIt' by binding the identifier squareIt to the lambda expression 'fun n -> n * n'.
    /// Function 'squareIt' has one parameter, n, and it returns the square of that parameter.
    let squareIt = fun n -> n * n

    /// F# provides the following more concise syntax to achieve the same result with less typing.
    let squareIt2 n = n * n

    /// The examples that follow mostly use the first style,
    /// 'let <function-name> = <lambda-expression>', to emphasize the similarities between the
    /// declaration of functions and the declaration of other types of values. However, all the
    /// named functions can also be written with the concise syntax. Some of the examples are
    /// written in both ways.


 /// Store the Value in a Data Structure.

 /// A first-class value can be stored in a data structure. The following code shows examples that
 /// store values in lists and in tuples.

 module FunctionValuesInDataStructures =

    /// Lists

    /// Storing integers and strings.
    let integerList = [ 1; 2; 3; 4; 5; 6; 7 ]
    let stringList = [ "one"; "two"; "three" ]

    /// You can't mix types in a list.  The following declaration causes a
    /// type-mismatch compiler error.
    //let failedList = [ 5; "six" ]

    /// In F# functions can be stored in a list, as long as the functions
    /// have the same signatures (types).

    /// Function doubleIt has the same signature as squareIt, declared previously.
    let squareIt = fun n -> n * n
    let doubleIt = fun n -> 2 * n

    /// Functions squareIt and doubleIt can be stored together in a list.
    let funList = [ squareIt; doubleIt ]

    /// Functions squareIt cannot be stored in a list together with a functions
    /// that has a different signature, such as the following body mass
    /// index (BMI) calculator.
    let BMICalculator =
        fun ht wt -> (float wt / float (squareIt ht)) * 703.0

    /// The following expression causes a type-mismatch compiler error.
    //let failedFunList = [ squareIt; BMICalculator ]

    /// Tuples.

    /// Integers and strings.
    let integerTuple = ( 1, -7 )
    let stringTuple = ( "one", "two", "three" )

    /// A tuple does not require its elements to be of the same type.
    let mixedTuple = ( 1, "two", 3.3 )

    /// Similary, function elements in tuples can have different signatures.
    let funTuple = ( squareIt, BMICalculator )

    /// Functions can be mixed with intgers, strings, and other types in
    /// a tuple. Identifier num was declared previously.
    let num = 10
    let moreMixedTuple = ( num, "two", 3.3, squareIt )

    /// To verify that a function name stored in a tuple does in fact evaluate to a function, the
    /// following example uses the 'fst' and 'snd' operators to extract the first and second
    /// elements from tuple 'funAndArgTuple'. The first element in the tuple is 'squareIt' and the
    /// second element is 'num'. Identifier 'num' is bound in a previous example to integer 10,
    /// a valid argument for the 'squareIt' function. The second expression applies the first
    /// element in the tuple to the second element in the tuple: 'squareIt num'.

    /// You can pull a fucntion out of a tuple and apply it. Both squareIt and num
    /// were defined previously.
    let funAndArgTuple = (squareIt, num)

    /// The following expression applies squareIt to num, returns 100, and
    /// then desplays 100.
    let result1 = (fst funAndArgTuple)(snd funAndArgTuple)
    System.Console.WriteLine(result1)

    /// Similarly, just as identifier 'num' and integer 10 can be used interchangeably, so can
    /// identifier 'squareIt' and lambda expression 'fun -> n * n.

    /// Make a tuple of values instread of identifiers.
    let funAndArgTuple2 = ((fun n -> n * n), 10)

    /// The following expression applies a squaring function to 10, returns
    /// 100, and then displays 100.
    let result2 = (fst funAndArgTuple2)(snd funAndArgTuple2)
    System.Console.WriteLine(result2)


/// Pass the value as an Argument

/// If a value has first-class status in a language, you can pass it as an argument to a function.
/// For example, it is common to pass integers and strings as arguments. The following code shows
/// integers and strings passed as arguments in F#.

module PassValueAsArgument =

    /// An integer is passed to squareIt.
    let num = 10
    let squareIt = fun n -> n * n

    let result3 = squareIt num
    System.Console.WriteLine(result3)

    /// String.
    /// Function repeatString concatenates a string with itself.
    let repeatString = fun (s: string) -> s + s

    /// A string is passed to repeatString. HelloHello is returned and displayed.
    let greeting = "Hello"

    let result4 = repeatString greeting
    System.Console.WriteLine(result4)


    /// If functions have first-class status, you must be able to pass them as arguments in the
    /// same way. Remember that this is the first characteristic of higher-order functions.

    /// In the following example, function 'applyIt' has two parameters, 'op' and 'arg'. If you
    /// send in a function that has one parameter for 'op' and an appropriate argument for the
    /// function to 'arg', the function returns the result of applying 'op' to 'arg'. In the
    /// following example, both the function argument and the integer argument are sent in the
    /// same way, by using their names.

    /// Define the function, again using lambda expression syntax.
    let applyIt = fun op arg -> op arg

    /// Send squareIt for the function, 'op' and num for the arument you want to
    /// apply squareIt to, 'arg'. Both 'squareIt' and 'num' are defined in previous
    /// examples. The result returned and displayed is 100.
    let result5 = applyIt squareIt num
    System.Console.WriteLine(result5)

    /// The following expression shows the concise syntax for the previous function definiton.
    let applyIt2 op arg = op arg
    let result6 = applyIt2 squareIt num
    System.Console.WriteLine(result6)


    /// The ability to send a function as an argument to another function underlies common
    /// abstractions in functional programming languages, such as map or filter operations.
    /// A map operation, for example, is a higher-order function that captures the computation
    /// shared by functions that step through a list, do something to each element, and then
    /// return a list of the results. You might want to increment each element in a list of
    /// integers, or to square each element, or to change each element in a list of strings to
    /// uppercase. The error-prone part of the computation is the recursive process that steps
    /// through the list and builds a list of the results to return. That part is captured in the
    /// mapping function. All you have to write for a particular application is the function that
    /// you want to apply to each list element individually (adding, squaring, changing case).
    /// That function is sent as an argument to the mapping function, just as 'squareIt' is sent
    /// to 'applyIt' in the previous example.

    /// F# provides map methods for most collection types, including 'lists', 'arrays', and
    /// 'sequences'. The following examples use 'lists'.
    /// The syntax is 'List.map <the function> <the list>'.

    /// The List integerList
    let integerList = [ 1; 2; 3; 4; 5; 6; 7 ]

    /// You can send the function argument by name, if an appropraite function
    /// is available. The following expression uses squareIt.
    let squareAll = List.map squareIt integerList
    printfn "%A" squareAll

    /// Or you can define the action to apply to each list element inline.
    /// For example, no function that tests for even integers has been defined,
    /// so the following expression defines the appropriate function inline.
    /// The function returns 'true' if 'n' is even; otherwise it returns 'false'.
    let evenONot = List.map (fun n -> n % 2 = 0) integerList
    printfn "%A" evenONot


/// Return the Value from a Function Call

/// Finally, if a function has first-class status in a language, you must be able to return it
/// as the value of a function call, just as you return other types, such as integers and strings.

module ReturnValueFromFunctionCall =

    /// The following function calls take integers and return them.
    let doubleIt = fun n -> 2 * n
    let squareIt = fun n -> n * n

    System.Console.WriteLine(doubleIt 3)
    System.Console.WriteLine(squareIt 4)

    /// The following function call returns a string.
    let str = "F#"
    let lowercase = str.ToLower()
    System.Console.WriteLine(lowercase)

    /// The following function call, declare inline, returns a Boolean vlue,
    /// The value displayed is 'true'.
    let result7 = (fun n -> n % 2 = 1) 15
    System.Console.WriteLine(result7)


    /// The ability to return a function as the value of a function call is the second
    /// characteristic of higher-order functions. In the following example, 'checkFor' is defined
    /// to be a function that takes one argument, 'item', and returns a new function as its value.
    /// The returned function takes a list as its argument, 'lst', and searches for 'item' in 'lst'.
    /// If 'item' is present, the function returns 'true'. If 'item' is not present, the function
    /// returns 'false'. As in the previous section, the following code uses a provided list
    /// function, List.exists, to search the list.

    let checkFor item =
        let functionToReturn = fun lst ->
                                 List.exists (fun a -> a = item) lst
        functionToReturn

    /// an integer list and a string list
    let integerList = [ 1; 2; 3; 4; 5; 6; 7 ]
    let stringList = [ "one"; "two"; "three" ]

    /// The returned function is given the name checkFor7.
    let checkFor7 = checkFor 7

    /// The result displayed when checkFor7 is applied to integerList is True.
    let result8 = checkFor7 integerList
    System.Console.WriteLine(result8)

    /// The following code repeats the process for "seven" in stringList
    let checkForSeven = checkFor "seven"

    /// The result displayed is False.
    let result9 = checkForSeven stringList
    System.Console.WriteLine(result9)


    /// The following example uses the first-class status of functions in F# to declare a
    /// function 'compose' that returns a compostion of two function arguments.

    /// Function 'compose' takes two arguments.  Each argument is a function
    /// that takes one argument of the same type.  The following declaration
    /// use lambda syntax.
    let compose =
        fun op1 op2 ->
            fun n ->
                op1 (op2 n)

    /// To clarify what you are returning, use a nested let expression:
    let compose2 =
        fun op1 op2 ->
            // Use a let expresson to build the function that will be returned.
            let funToReturn = fun n ->
                                op1 (op2 n)
            funToReturn

    /// Or, integrating the more concise syntax:
    let compose3 op1 op2 =
        let funToReturn = fun n ->
                            op1 (op2 n)
        funToReturn

    /// For a shorter version, try "Curried Funtions" later.


    /// The following code sends tow functions as argument to 'compose', both of which take a single
    /// argument of the same type.  The return value is a new function that is a compostiton of the
    /// two function arguments.

    /// Functions squareIt and doubleIt were defined in a previous example.
    let doubleAndSquare = compose squareIt doubleIt

    let result10 =  doubleAndSquare 3
    System.Console.WriteLine(result10)

    let squareAndDouble = compose squareIt doubleIt
    /// The following expression squares 3, doulbe 9, returns 18, and
    /// then desplays 18.
    let result11 = squareAndDouble 3
    System.Console.WriteLine(result11)

    /// Note:  F# provides two operators, '<<' and '>>', that compose functions.
    /// For example:
    let squareAndDouble2 = doubleIt << squareIt
    /// is the equivalent of 'squareAndDouble' previously defined.


    /// The following example  of returning a function as the value of a function call creates a
    /// simple guessing game. To create a game, call 'makeGame' with the value that you want
    /// someone to guess sent in for 'target'. The return value from function makeGame is a
    /// function that takes one argument (the guess) and reports whether the guess is correct.

    let makeGame target =
        // Build a lamda expession that is a function that plays the game.
        let game = fun guess ->
                        if guess = target then
                            System.Console.WriteLine("You win!")
                        else
                            System.Console.WriteLine("Wrong, Try again.")
        // Now just return it.
        game

    /// The following code calls 'makeGame', sending the value '7' for 'target'. Identifier
    /// 'playGame' is bound to the returned lambda expression. Therefore, 'playGame' is a function
    /// that takes as its one argument a value for 'guess'.

    let playGame = makeGame 7
    /// Send in some guesses.
    playGame 2  // Wrong, Try again.
    playGame 9  // Wrong, Try again.
    playGame 7  // You win!


/// Curried Functions

module CurriedFunctions =

    ///  Many of the examples in the previous section can be written more concisely by taking
    /// advantage of the implicit 'currying' in F# function declarations. Currying is a process
    /// that transforms a function that has more than one parameter into a series of embedded
    /// functions, each of which has a single parameter. In F#, functions that have more than one
    /// parameter are inherently curried. For example, 'compose' from the previous section can be
    /// written as shown in the following concise style, with three parameters.

    let compose4 op1 op2 n = op1 (op2 n)

    /// However, the result is a function of one parameter that returns a function of one
    /// parameter that in turn returns another function of one parameter, as shown in
    /// 'compose4curried'.

    let compose4curried =
        fun op1 ->
            fun op2 ->
                fun n -> op1 (op2 n)

    /// You can access this function in several ways. Each of the following examples returns and
    /// displays '18'. You can replace 'compose4' with 'compose4curried' in any of the examples.

    /// Access one layer at a time
    let doubleIt n = 2 * n
    let squareIt n = n * n

    let result12 = ((compose4 doubleIt) squareIt) 3
    System.Console.WriteLine(result12)

    /// Access as in the original compose examples, sending arguments for
    /// op1 and op2, then applying the resulting fucntin to a value.
    let result13 = (compose4 doubleIt squareIt) 3
    System.Console.WriteLine(result13)

    /// Access by sending all three arguments at the same time.
    let result14 = compose4 doubleIt squareIt 3
    System.Console.WriteLine(result14)

    /// Note: You can restrict currying by enclosing parameters in tuples.


    /// The following example uses implicit currying to write a shorter version of 'makeGame'.
    /// The details of how 'makeGame' constructs and returns the 'game' function are less
    /// explicit in this format, but you can verify by using the original test cases that the
    /// result is the same.

    let makeGame2 target guess =
        if guess = target then
            System.Console.WriteLine("You win!")
        else
            System.Console.WriteLine("Wrong. Try again.")

    let playGame2 = makeGame2 7
    playGame2 2
    playGame2 9
    playGame2 7

    let alphaGame2 = makeGame2 'q'
    alphaGame2 'c'
    alphaGame2 'r'
    alphaGame2 'j'
    alphaGame2 'q'


/// Identifier and Function Definition Are Interchangeable

/// The variable name 'num' in the previous examples evaluates to the integer 10, and it is no
/// surprise that where 'num' is valid, 10 is also valid. The same is true of function identifiers
/// and their values: anywhere the name of the function can be used, the lambda expression to
/// which it is bound can be used.

module IdentifierFunctionInterchangeable =

    /// The following example defines a 'Boolean' function called 'isNegative', and then uses the
    /// name of the function and the definition of the function interchangeably. The next three
    /// examples all return and display 'False'.

    let isNegative = fun n -> n < 0

    /// This example uses the names of the function arguemnt and the integer
    /// argument.  Identifier 'num' is defined in the previous example.
    let num = 10
    let applyIt = fun op arg -> op arg
    let result15 = applyIt isNegative num
    System.Console.WriteLine(result15)

    /// This example substitutes the value that 'num' is boud to for 'num', and the
    /// argument.
    let result16 = applyIt (fun n -> n < 0) 10
    System.Console.WriteLine(result16)

    /// To take it one step further, supstitute the value that 'applyIt' is bound to
    /// for 'applyIt'.
    let result17 = (fun op arg -> op arg) (fun n -> n < 0) 10
    System.Console.WriteLine(result17)