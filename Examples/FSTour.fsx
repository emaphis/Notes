
/// This article will act as a tour through some of the key features of the F# language and give you some code snippets that you can
/// execute on your machine.
///
/// There are two primary concepts in F#: functions and types. This tour will emphasize features of the language which fall
/// into these two concepts.

/// Functions and Modules
/// The most fundamental pieces of any F# program are 'functions' organized into 'modules'. 'Functions' perform work on inputs to 
/// produce outputs, and they are organized under 'Modules', which are the primary way you group things in F#. They are defined using 
/// the 'let' binding, which give the function a name and define its arguments.

module BaiscFuntions =

    /// You can use 'let' to define a function. This one accepts an integer.
    /// Parentheses are optional for function arguments, except for when you use and explicit type annotation.
    let sampleFunction1 x = x*x + 3

    /// Apply the function, naming the function return result using 'let'.
    /// The variable type is is inferred from the function return type.
    let result1 = sampleFunction1 4573

    /// This line uses '%d' to print the result as an integer. This is type-safe.
    /// If 'result' were not of type 'int', then the line would fail to compile.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// When needed, annotate the type of a parameter name using '(argument:type)'. Parentheses are required.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    /// Conditionals use if/then/elif/else.
    ///
    /// Note that F# uses whitespace indentation-aware suntax.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0
    
    let result3 = sampleFunction3 (6.5 + 4.5)
    
    /// This line uses '%f' to print the result as a float. As with the '%d' above, this is type-safe.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3


/// 'let' bindings are also how you bind a value to a name, similar to a variable in other languages. 'let' bindings are 'immutable' by 
/// default, which means that once a value or function is bound to a name, it cannot be changed in-place. This is in contrast to variables
/// in other languages, which are 'mutable', meaning their values can be changed at any point in time. If you require a mutable binding,
//  you can use 'let mutable ...' syntax.

module Immutability =

    /// Binding a vlue to a name by 'let' makes it immutable.
    ///
    /// The second line of code fails to compile because 'number' is immutable and bound.
    /// Re-defining 'number' to a different value is not allowed in F#.
    let number = 2
    //let number = 3

    /// A 'mutable' binding. This is required to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    /// When mutating a value, use '<-' to assign a new value.
    ///
    /// Note that '=' is not the same as this. '=' is used to test equality.
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber


/// Number, Booleans, and Strings
/// As a .NET language, F# supports the same underlying primitive types that exist in .NET
/// Here is how various numberic types are represented inF#

module IntegersAndNumbers =

    /// This is a sample integer
    let sampleInteger = 176

    /// This is a sample floating point number.
    let sampleDouble = 4.1

    /// This computed a new number by some arithmetic. Numberic types are converted using
    /// functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// This a list of the numbers from 0 to 99.
    let sampleNumbers = [0 .. 99]

    /// This is a list of all tuples containing all the numbers from 0 to 99 and their squares.
    let sampleTableOfsquares = [ for i in 0 .. 99 -> (i,i*i) ]

    /// The next line prints a list that includes tuples, using '%A' for generic printing
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfsquares

/// Here's what Boolean values and performing basic conditonal logic looks like:

module Booleans =

    /// Booleans values are 'true' and 'false'
    let boolean1 = true
    let boolean2 = false

    /// Operators on booleans are 'not', '&&' and '||'
    let boolean3 = not boolean1 && (boolean2 || false)

    /// This line used '%b' to print a boolean value. This is type-safe.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3


/// Here's what basic 'string' manipulationlooks like:

module StringManipulation =

    /// Strings use double quotes.
    let string1 = "Hello"
    let string2 = "world"

    /// String can also use @ to creat a verbatim string literal.
    /// This will ignore escape characters such as '/', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"

    /// String literals can also use triple-quotes.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// String concatenation is normally done with the '+' operator.
    let helloWorld = string1 + " " + string2

    /// This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" helloWorld

    /// Substrings use the indexer notatioin.  This line extacts the first 7 characters as a substring
    /// Note that like many languages, Strings are zero-indexed in F#
    let substring = helloWorld.[0..6] 
    printfn "%s" substring


 /// Tuples
 /// 'Tuples' are a big deal in F#. They are a grouping of unnamed, but ordered values, that can be treated as values themselves. Think of
 /// them as values which are aggregated from other values. They have many uses, such as conveniently returning multiple values from a
 /// function, or grouping values for some ad-hoc convenience.

 module Tupes =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple.
    ///
    /// F# Type Inference will automatically generalize the function to have a generic type,
    /// meaning that it will work with any compatiple type.
    let swapElems (a, b) = (b, a)

    printfn "The result of swaping (1, 2) IS %A" (swapElems(1,2))

    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A\ttuple2: %A" tuple1 tuple2

/// As of F# 4.1, you can also create 'struct' tuples. These also interoperate fully with C#7/Visual Basic 15 tuples, which are
//  also 'struct' tuples:

    /// Tuples are normally objects, but they caon also be reprsented as structs
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertible wiht object tuples (often called reference tuples).
    ///
    /// The seond line below will fail to compile because of this. Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    /// Although you can:
    let convertFromStructTuple (struct(a,b)) = (a,b)
    let convertToStructTuple(a,b) = struct(a,b)

    printfn "Struct Tuple: %A\nReference tuple made from Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)

    /// Ift's important to note that because struct tuples are value types, they cannot be implicitly converted to reference tuples, or vice
    /// versa. You must explicitly convert between a reference and struct tuple.

/// Pipelines and Composition
/// Pipe operators (|>, <|, ||>, <||, |||>, <|||) and composition operators (>> and <<) are used extensively when
/// processing data in F#. These operators are functions which allow you to establish "pipelines" of functions in a flexible manner.
/// The following example walks through how you could take advantage of these operators to build a simple functional pipeline.

module PipelinesAndComposition =

    /// Squares a value.
    let square x = x * x

    /// Adds 1 to a value
    let addOne x = x + 1

    /// Tests if an integer value is odd via modulo.
    let isOdd x = x % 2 <> 0

    /// A list of 5 numbers. More on lists later.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Given a list of integers, it filters out the even numbers,
    /// squares the resulting odds, and adds 1 to the squared odds.
    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers) 

    /// A shorter way to write 'squareOddValuesAndAddOne' is to nest each
    /// sub-result into the function calls themselves.
    ///
    /// This makes the function much shorter, but it's difficult to see the
    /// order in which the data is processed.
    let squareOddValuesAndAddOneNested values =
        List.map addOne (List.map square (List.filter isOdd values)) 

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    /// A preferred way to write 'squareOddValuesAndAddOne' is to use F# pipe operators.
    /// This allows you to avoid creating intermediate results, but is much more readable
    /// than nesting function calls like 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)

    /// You can shorten 'squareOddValuesAndAddOnePipeline' by moving the second `List.map` call
    /// into the first, using a Lambda Function.
    ///
    /// Note that pipelines are also being used inside the lambda function.  F# pipe operators
    /// can be used for single values as well.  This makes them very powerful for processing data.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)

    /// Lastly, you can eliminate the need to explicitly take 'values' in as a parameter by using '>>'
    /// to compose the two core operations: filtering out even numbers, then squaring and adding one.
    /// Likewise, the 'fun x -> ...' bit of the lambda expression is also not needed, because 'x' is simply
    /// being defined in that scope so that it can be passed to a functional pipeline.  Thus, '>>' can be used
    /// there as well.
    ///
    /// The result of 'squareOddValuesAndAddOneComposition' is itself another function which takes a
    /// list of integers as its input.  If you execute 'squareOddValuesAndAddOneComposition' with a list
    /// of integers, you'll notice that it produces the same results as previous functions.
    ///
    /// This is using what is known as function composition.  This is possible because functions in F#
    /// use Partial Application and the input and output types of each data processing operation match
    /// the signatures of the functions we're using.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers (squareOddValuesAndAddOneComposition numbers)

/// The above sample made use of many features of F#, including list processing functions, first-class functions, and
/// partial application. Although a deep understanding of each of those concepts can become somewhat advanced, it
/// should be clear how easily functions can be used to process data when building pipelines.


/// Lists, Arrays, and Sequences
/// Lists, Arrays and Sequences are three primary collections types in the F# core library.

/// 'Lists' are ordered, immutable collections of elements of the same type. They are singly-linked lists, which means
/// they are meant for enumeration, but a poor choice for random access and concatenation if they're large. This in
/// contrast to Lists in other popular languages, which typically do not use a singly-linked list to represent Lists.

module Lists =

    /// Lists are difined using [ ... ], This is an emptu list.
    let list1 = []

    /// This is a list wiht 3 elements, ';' is used to separate elements on the same line.
    let list2 = [ 1; 2; 3 ]

    /// You can also separate element by placing them on their own lines.
    let list3 = [
        1
        2
        3
    ]

    /// This is a list of integers from 1 to 1000
    let numberList = [ 1 .. 1000 ]

    /// List can also be generated by computations, This a list containing
    /// all the days of the year.
    let daysList =
        [ for month in 1 .. 12 do
            for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                yield System.DateTime(2017, month, day) ]
    
    /// Print the first five elements of 'daysList' using 'List.take'.
    printfn "The first 5 days of 2017 are: %A"
    /// Computations can include conditionals.  This is a list containing the tuples
    /// which are the coordinates of the black square on a chess board.
    let blackSquares =
        [ for i in 0 .. 7 do
            for j in 0 .. 7 do
                if (i+j) % 2 = 1 then
                 yield (i,j) ]
    
