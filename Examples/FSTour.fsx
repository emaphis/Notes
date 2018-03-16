///
/// This article will act as a tour through some of the key features of the F# language and give
/// you some code snippets that you can execute on your machine.
///
/// There are two primary concepts in F#: functions and types. This tour will emphasize features
/// of the language which fall into these two concepts.


/// Functions and Modules

/// The most fundamental pieces of any F# program are 'functions' organized into 'modules'.
/// 'Functions' perform work on inputs to produce outputs, and they are organized under 'Modules',
/// which are the primary way you group things in F#. They are defined using the 'let' binding,
/// which give the function a name and define its arguments.

module BaiscFuntions =

    /// You can use 'let' to define a function. This one accepts an integer.
    /// Parentheses are optional for function arguments, except for when you use and explicit type
    /// annotation.
    let sampleFunction1 x = x*x + 3

    /// Apply the function, naming the function return result using 'let'.
    /// The variable type is is inferred from the function return type.
    let result1 = sampleFunction1 4573

    /// This line uses '%d' to print the result as an integer. This is type-safe.
    /// If 'result' were not of type 'int', then the line would fail to compile.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    /// When needed, annotate the type of a parameter name using '(argument:type)'. Parentheses are
    /// required.
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


/// 'let' bindings are also how you bind a value to a name, similar to a variable in other languages.
/// 'let' bindings are 'immutable' by default, which means that once a value or function is bound to
/// a name, it cannot be changed in-place. This is in contrast to variables in other languages, which
/// are 'mutable', meaning their values can be changed at any point in time. If you require a mutable
/// binding, you can use 'let mutable ...' syntax.

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

 /// 'Tuples' are a big deal in F#. They are a grouping of unnamed, but ordered values, that can be
 /// treated as values themselves. Think of them as values which are aggregated from other values.
 /// They have many uses, such as conveniently returning multiple values from a function, or
 /// grouping values for some ad-hoc convenience.

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

/// As of F# 4.1, you can also create 'struct' tuples. These also interoperate fully with C#7/Visual
/// Basic 15 tuples, which are also 'struct' tuples:

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

    /// It's important to note that because struct tuples are value types, they cannot be
    /// implicitly converted to reference tuples, or vice versa. You must explicitly convert between
    /// a reference and struct tuple.


/// Pipelines and Composition

/// Pipe operators (|>, <|, ||>, <||, |||>, <|||) and composition operators (>> and <<) are used
/// extensively when processing data in F#. These operators are functions which allow you to
/// establish "pipelines" of functions in a flexible manner.

/// The following example walks through how you could take advantage of these operators to build a
/// simple functional pipeline.

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

/// 'Lists' are ordered, immutable collections of elements of the same type. They are singly-linked
/// lists, which means they are meant for enumeration, but a poor choice for random access and
/// concatenation if they're large. This in contrast to Lists in other popular languages, which
/// typically do not use a singly-linked list to represent Lists.

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
    let numberList1 = [ 1 .. 1000 ]

    /// List can also be generated by computations, This a list containing
    /// all the days of the year.
    let daysList =
        [ for month in 1 .. 12 do
            for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                yield System.DateTime(2017, month, day) ]

    /// Print the first five elements of 'daysList' using 'List.take'.
    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    /// Computations can include conditionals.  This is a list containing the tuples
    /// which are the coordinates of the black square on a chess board.
    let blackSquares =
        [ for i in 0 .. 7 do
            for j in 0 .. 7 do
                if (i+j) % 2 = 1 then
                 yield (i,j) ]


    /// Lists can be transformed using 'List.map' and other functional programming combinators.
    /// This definition produces an new list by squaring the numbers in numberList, using pipeline
    /// operator to pass an agument to List.map
    let squares =
        numberList1
        |> List.map (fun x -> x*x)

    /// There are many other list combinators.  The following computes the sum of the square of the
    /// numbers divisible by 3.
    let sumOfSquares =
        numberList1
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares


/// Arrays are fixed-size, mutable collections of elements of the same type. They support fast random
/// access of elements, and are faster than F# lists because they are just contiguous blocks of
/// memory.

module Arrays =

    /// This is The empty array.  Note that the suntax is similar to that of Lists, but uses '[| ... |]'.
    let array1 = [| |]

    /// Arrays are specified using the same range of constructs as lists.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// This is an array of numbers from 1 to 1000.
    let array3 = [| 1 .. 1000 |]

    /// This is an array containing only the worlds "hello" and "world".
    let array4 =
        [| for word in array2 do
                if word.Contains("l") then
                    yield word |]

    /// This is an array initialized by index and containing the even numbers from 0 to 2000
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Sub-arrays are extracted using slicing notation
    let evenNumbersSlice = evenNumbers.[0..500]

    /// You can loop over arrays and lists using 'for' loops.
    for word in array4 do
        printf "word: %s" word

    /// You can modify the contents of an array element by using the left arrow assignment operator.
    array2.[1] <- "WORLD!"

    /// You can transform arrays using 'Array.map' and other functional programming operations.
    /// The efollowing calculates the sum of the lengths of the words that star with 'h'
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)
    
    printfn "The sum of the lengs of the words in Array2 that begin with 'h': %d" sumOfLengthsOfWords


/// Sequences are a logical series of elements, all of the same type. These are a more general
/// type than Lists and Arrays, capable of being your "view" into any logical series of elements.
/// They also stand out because they can be *lazy*, which means that elements can be computed only
/// when they are needed.

module Sequences =

    /// This is the empty sequence.
    let seq1 = Seq.empty

    /// This is a sequence of values
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "again" }

    /// This is an on-demand sequence from 1 to 1000.
    let numberSeq = seq { 1 .. 1000 }

    /// This is a sequence producning the words "hello" and "world"
    let seq3 =
        seq { for word in seq2 do
                if word.Contains("l") then
                    yield word }

    /// This sequence producing the even numbers up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This example uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// This example shows the first 100 elements of random walk
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


 /// Recursive Functions

 /// Processing collections or sequences of elements is typically done with recursion in F#. Although
 /// F# has support for loops and imperative programming, recursion is preferred because it is easier
 /// to guarantee correctness.

 module RecursiveFunctions =

    /// This example shows a recursive function that computes the facotial of an
    /// integer.  It uses 'let rec' to define a recursive function.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d" (factorial 6)

    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatesCommonFactor a b =
        if a = b then b
        elif a < b then greatesCommonFactor a (b - a)
        else greatesCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatesCommonFactor 300 630)

    /// This example computes the sum of a list of integers using recursion
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    let oneThroughTen = [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]

    printfn "The sum 1-10 is %d" (sumList oneThroughTen)

    /// This makes 'sumList' tail recursive, using a helper functio with a result accumulator.
    let rec sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An approach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)

/// F# also has full support for Tail Call Optimization, which is a way to optimize recursive calls
/// so that they are just as fast as a loop construct.


/// Record and Discrimated Union Types

/// Record and Union types are two fundamental data types used in F# code, and are generally the
/// best way to represent data in an F# program. Although this makes them similar to classes in
/// other languages, one of their primary differences is that they have structural equality semantics.
/// This means that they are "natively" comparable and equality is straightforward - just check if
/// one is equal to the other.

/// Records are an aggregate of named values, with optional members (such as methods). If you're
/// familiar with C# or Java, then these should feel similar to POCOs or POJOs - just with structural
/// equality and less ceremony.

module RecordTypes =

    /// This example shows how to define a new record type.
    type ContactCard =
        { Name      : string

    /// This example shows how to instantiate a record type
          Phone     : string
          Verified  : bool }
    let contact1 =
        { Name = "Alf"
          Phone = "(216) 555-0157"
          Verified = false }

    /// You can also do this on the same line with ';' separators.
    let contactOnSameLine = { Name = "Alf"; Phone = "(216) 555-0157"; Verified = false }

    /// This example shows how to use "copy-and-update" on record values. It creates
    /// a new record value that is a copy of contact1, by has different values for
    /// the 'Phone' and 'Verified' fields.
    let contact2 =
        { contact1 with
            Phone = "(216) 555-0112"
            Verified = true }

    /// This example show how to write a function that processes a record value.
    /// It converts a 'ContactCard' object to a string
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    /// This is an example of a Record with a memeber.
    type ContactCardAlternate =
        { Name      : string
          Phone     : string
          Address   : string
          Verified  : bool }

        /// Members can implement object-oriented members.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    /// Records can also be represented as structs via the 'Struct' attribute.
    /// This is helpful in situations where the performance of structs outweiighs
    /// the flexiblity of reference types.
    [<Struct>]
    type ContactStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


/// Discriminated Unions (DUs) are values which could be a number of named forms or cases.
/// Data stored in the type can be one of several distinct values.

module DiscrimatedUnions =

    /// The following represents the suit of a playing card.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// A Discrinated Union can also be use to represent the fank of a playing card.
    type Rank =
        /// Represents the ran of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Discriminated Unions can also implement object-oriented members.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// This is a record type that combines a Suit and a Rank.
    /// It's common to use both Records and Discriminate Unions when representing data.
    type Card = { Suit: Suit; Rank: Rank }

    /// This computes a list representing all the cards in the deck.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades ] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    /// This example converts a 'Card' object to a string
    let showPlayingCard (c: Card) =
        let rankString =
            match c.Rank with
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString =
            match c.Suit with
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hears"
        rankString + " of " + suitString

    /// This example prints all the cards in a playing deck.
    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)

    /// Single-case DUs are often used for demain modeling.  This can buy extra type safety
    /// over primitive types such as strings and int.
    ///
    /// Single-case DUs cannot be implicitly converted to or from the type they wrap.
    /// For example, a function which takes in an Address connot accept a string as that input
    /// or vice versa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    /// You can easily instantiate a single-case DU as follows.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// When you need the value, you can unwrap the underlying value with a simple function.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    /// Printing single-case DUs is simple with unwrapping functions.
    printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

/// As the above sample demonstrates, to get the underlying value in a single-case Discriminated
/// Union, you must explicitly unwrap it.

/// Additionally, DUs also support recursive definitions, allowing you to easily represent trees and
/// inherently recursive data. For example, here's how you can represent a Binary Search Tree with
/// 'exists' and 'insert' functions.


    /// Discriminated Unions also support recursive definitions
    ///
    /// This represents a Binary Search Tree, with one case being the Empty Tree,
    /// and the other being a Node wiht a value and two subrees.
    type BST<'T> =
        | Empty
        | Node of vale:'T * left:BST<'T> * right: BST<'T>

    /// Check if an item exists in the binary search tree.
    /// Searches recursively using Pattern Matching.  Returns true if it exists; otherwise false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left)  // Check the left subtree.
            else (exists item right)  // Check ther right subtree

    /// Insem is already present, it does not insert anything. (set)
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node   // No need to insert, it already exists; return node.
            elif item < x then Node(x, insert item left, right)  // Call into left subtree.
            else Node(x, left, insert item right)  // Call into right subtree

/// Because DUs allow you to represent the recursive structure of the tree in the data type,
/// operating on this recursive structure is straightforward and guarantees correctness. It is also
/// supported in pattern matching, as shown below.


    /// Discriminated Unions can also be represented as structs via the 'struct' attribute.
    /// This is helpful in situations where the performance of structs outweighs
    /// the flexibility of reference types.
    ///
    /// However, there are two imprortant things to know when doing this:
    ///     1. A struct DU cannot be recursively-defined
    ///     2. A struct DU must have unique names for each of it's cases.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Pattern Matching

/// Pattern Matching is the F# language feature which enables correctness for operating on F# types.
/// In the above samples, you probably noticed quite a bit of 'match x with ...' syntax. This
/// construct allows the compiler, which can understand the "shape" of data types, to force you to
/// account for all possible cases when using a data type through what is known as Exhaustive Pattern
///  Matching. This is incredibly powerful for correctness, and can be cleverly used to "lift" what
/// would normally be a runtime concern into compile-time.

module PatternMatching =

    /// A record for a person's first and last name
    type Person = {
        First : string
        Last  : string
    }

    /// A Discriminated Union of 3 different kins of employees.
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Count everyone underneath the employee in the management hierarchy,
    /// including the employee.
    let rec countReports(emp: Employee) =
        1 + match emp with
            | Engineer(_id) ->
                0
            | Manager(_id, reports) ->
                reports |> List.sumBy countReports
            | Executive(_id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant

    /// Find all managers/executives name "Dave" who do not have any reports.
    /// This uses the 'function' shorthand as a lambda expression
    let rec findDaveWithOpenPosition(emps: List<Employee>) =
        emps
        |> List.filter (function
                        | Manager({First = "Dave"}, []) -> true  // [] matches an empty list.
                        | Executive({First = "Dave"}, [], _) -> true
                        | _ -> false) // '_' is a wildcard pattern that matches anything
                                      // This handles the "or else" case/

    open System

    /// You can alos use the shorthand function construct for pattern matching,
    /// which is useful when you're writing functions which make use of Partial Application.
    let private parseHelper f = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
        | Some dto -> printfn "It parsed!"
        | None -> printfn "It didn't parse!"

    /// Define some more functions which parse with the helper function.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

/// Something you may have noticed is the use of the '_' pattern. This is known as the Wildcard
/// Pattern, which is a way of saying "I don't care what something is". Although convenient, you
/// can accidentally bypass Exhaustive Pattern Matching and no longer benefit from compile-time
/// enforcements if you aren't careful in using '_'. It is best used when you don't care about
/// certain pieces of a decomposed type when pattern matching, or the final clause when you have
/// enumerated all meaningful cases in a pattern matching expression.


    /// Active Patterns are another powerful construct to use with pattern matching.
    /// They allow you to partition input data into custom forms, decomposing them at
    /// the pattern match call site.

    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Pattern Matching via 'function' keyword and Active Patterns often look like this.
    let printParseResult = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

    /// Call the printer with some different values to parse.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Optional Types

/// One special case of Discriminated Union types is the Option Type, which is so useful that it's
/// a part of the F# core library.

/// The Option Type is a type which represents one of two cases: a value, or nothing at all. It is
/// used in any scenario where a value may or may not result from a particular operation. This then
/// forces you to account for both cases, making it a compile-time concern rather than a runtime
/// concern. These are often used in APIs where 'null' is used to represent "nothing" instead, thus
/// eliminating the need to worry about 'NullReferenceException' in many circumstances.

module OptionValues =

    /// First, define a zip code defined via Single-case Discriminated Union.
    type ZipCode = ZipCode of string

    /// Next, define a type where the ZipCode is optional.
    type Customer = { ZipCode: ZipCode option }

    /// Next, define an interface type that represents an object to compute the shipping zone for
    /// the customer's given implementations for the 'getState' and 'getShippingZone' abstract methods.
    type IShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Next, calculate a shipping zone for a customer using a calculator instance.
    /// This uses combinators in the Option module to allow a functional pipeline for
    /// transforming data with Optionals.
    let CustomerShippingZone (calculator: IShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone


/// Units of Measure

/// One unique feature of F#'s type system is the ability to provide context for numeric literals
/// through Units of Measure.

/// Units of Measure allow you to associate a numeric type to a unit, such as Meters, and have
/// functions perform work on units rather than numeric literals. This enables the compiler to
/// verify that the types of numeric literals passed in make sense under a certain context, thus
/// eliminating runtime errors associated with that kind of work.

module UnitsOfMeasure =

    /// First, open a collection of common unit names.
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Define a unitized constant
    let sampleValue1 = 1600.0<meter>

    /// Next, define a new unit type.
    [<Measure>]
    type mile =
        /// Conversionfactor mile to meter.
        static member asMeter = 1609.34<meter/mile>

    /// Define a unitized constant
    let sampleValue2 = 500.0<mile>

    /// Compute metric-system constant
    let sampleValue3 = sampleValue2 * mile.asMeter

    /// Values using Units of Measure can be used just like the primative numberic type for things
    /// like printing
    printfn "After a %f meter race I would walk %f miles which would be %f meters" sampleValue1 sampleValue2 sampleValue3

/// The F# Core library defines many SI unit types and unit conversions.


/// Classes and Interfaces

/// F# also has full support for .NET classes, Interfaces, Abstract Classes, Inheritance, and so on.

/// Classes are types that represent .NET objects, which can have properties, methods, and events
/// as its Members.

module DefiningClasses =

    /// A simple two-dimensional Vector class.
    ///
    /// The class's constructor is on the fist line,
    /// and takes tow argumens: dx and dy, both of type 'double'.
    type Vector2D(dx : double, dy : double) =

        /// This internal field atores the length of the vector, computed when the
        /// object is constructed
        let length = sqrt (dx*dx + dy*dy)

        /// 'this' specifies a name for the objext's self-identifier.
        /// In stance methods, it must appear before the member name.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// This member is a method.  The previous members were properties.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    /// This is how you instantiate the Vector2D class.
    let vector1 = Vector2D(3.0, 4.0)

    /// Get a new scaled vector object, without modifying the original object.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length


/// Defining generic classes is also very straightforward.

module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) =

        /// This internal field stores the states in a list.
        let mutable states = [ initialElement ]

        /// Add a new element to the list of states.
        member this.UpdateState newState =
            states <- newState :: states   // use the '<-' operator to mutate the value.

        /// Get the entire list of historical states.
        member this.History = states

        /// Get the latest state.
        member this.Current = states.Head

    /// An 'int' instance of the state tracker class. Note that the type parameter is inferred.
    let tracker = StateTracker 10

    /// Add a state
    tracker.UpdateState 17


/// To implement an interface, you can use either 'interface ... with' syntac or an Object Expression

module ImplementingInterfaces =

    /// This is a type that implements IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        /// This is the implementation of IDisposable members.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// This is an object that implements IDisposable via an Object Expression
    /// Unlike other languages such as C# or Java, a new type definition is not needed
    /// to implement an interface
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }
