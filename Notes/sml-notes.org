
* Expressions and variables

** Syntax and semantics

Three questions

1 Syntax is just how you write something

2 Semantics is what that something means
- Type-checking (before the program runs)
-- extend the static environment
-- Produces a type or fails
-- int bool unit

3 Evaluation (as program runs)
-- extend the dynamic environment
-- Produces a value (exception or infinite-loop)

** Values
- All a values are expressions
- Not all expressions are values
- Every value "evaluates to itself" in zero steps
-- 34, 17, 42 have type intital
   true, false have type bool
   () has type unit

** A variable
1 Syntax:
- sequence of letters, digits, _, not starting with digit
2 Type checking:
- Look up in current static environment
-- if not there, fail
3 Evaluation:
- Look up value in current dynamic environment

** A variable binding
val x = e;

1 Syntax:
- Keyword val and punctuation = and ;
- Variable x
- Expression e
-- Many forms of these, most containing subexpressions

2 Type checking:

3 Evaluation

** Addition

1 Syntax
- e1 + e2 where e1 and e2 are expressions

2 Type-checking
- If e1 and e2 have a type int
  then e1 + e2 has type int.

3 Evaluation:
- If e1 evaluates to v1 and e2 evaluate to v2,
  then e1 + e2 evaluates to the sum of v1 and v2

** Conditional expression
1 Syntax
- if e1 then e2 else e3
  where if, then, else are key words and  
  e1 e2 and e3 are subexpressions

2 Type-checking
  e1 must be of type bool
  e2 and e3 must be of the same type 't' but can be any type 't'
  The type of the entire expression is also 't'

3 Evaluation
  Evaluate e1 to a value v1
  if v1 is true, evaluate e2 to v2, then the result of the if expression is v2
  else evaluate e3 to v3, then the result of the expression is v3

** Less-than
1 Syntax:
  e1 < e2
  where '<' is an operator and e1 and e2 are subexpressions

2 Type checking
  e1 and e2 must be ordered types the result of expression is type bool.

3 Evaluation
  e1 and e2 are evaluated, if the value of e1 is less than the value
  of e2 then the value of the expression is true else the value is false

** Shadowing (useful for understanding functions

- Multiple bindings of same variable

-- Multiple variable bindings of the same variable is poor style
--- confusing

** Function binding
1 Syntax: fun x0 (x1 : t1, ..., xn : tn) = e

2 Evaluation: A function is a value. (Not evaluated yet)
  Adds x0 t0 environment so later expressions can call it
  (Function call semantics will also allow recursion

3 Type checking:
  Adds binding x0 : (t1 * ... * tn) -> t if
  Can type-check body e to have type t in the static environment
   containing
  - "Enclosing" static environment
  - x1: t1, ..., xn : tn   (arguments with their types)
  - x0: (t1 * ... * tn) -> t  for recursion

** Function calls
1 Syntax e0 (e1, ..., en)
  - Parentheses optional on functions of only one parameter.

2 Type-checking:
  if:
  - e0 has some type (t1 * ... * tn) -> t
  - e1 has type t1, .. en has type tn
  then:
  - e0 (e1,...,en) has type t
  Example: pow(x,y-1) has type int.

3 Evaluation:
  a. (under current dynamic environment) evaluate e0 to a 
     function fun x0 (x1 : t1, ..., xn : tn) = e
     - since call type-checked, result will be a function
  b. (under current dynamic environment) evaluate arguments to
     values v1, ..., vn
  c. Result is evaluation of e in an environment extended to map
     x1 to v1, ..., xn to vn
     - (An environment is actually the environment where the function
        was defined, and includes x0 for recursion)

** Tuples
- Fixed number of pieces that may have different types

*** Pairs (2-tuples)
**** build
1 Syntax (e1,e2)
2 Evaluation
  Evaluate e1 to v1 and e2 to v2 - result is (v1, v2)
  - a pair of values is a value
3 Type-checking
  If e1 has type ta and e2 has type tb, then the pair expression has
  type ta * tb  - a new kind of type

**** Access
1 Syntax  #1 e  and #2 e
2 Evaluation:
  Evaluate e to a pair of values and return first or second piece
  - Example: if e is a variable x, then look up x in environment
3 Type-checking
  if e has type ta * tb, then #1 e has type ta and #2 w has type tb

*** Tuples
1 Syntax:  (e1,e2,...,en)
2 Types: ta * tb * ... * tn
3 Access:  #1 e, #2 e, #3 e, ... #n e

** Lists
- Can have any number of elements
- But all elements must be of the same type

*** build
- Empty list is a value:  []

- a list of values is a value: elements separated by commas:
  [v1, v2, ..., vn]

3 Evaluation:
  If e1 evaluates to v and e2 evaluates to a list [v1,...,vn],
  then e1::e1 evaluates to [v,...,vn]
    e1::e2 is pronounced "cons".

*** access
- null e - evaluates to true if and only if e evaluates to []
- if e evaluates to [v1,v2,...,vn] the hd e evaluates to v1
   - raise exception if e evaluates to [].
- if e evaluates to [v1,v2,...,vn] the tl e evaluates to
  [v2,...,vn]
   - raise an exception of e evaluates to []
   - the result is another list.

*** type-checking
- int list, bool list, int list list, (int*int) list,
   (int list * int) list
- [] is any type of list - 'a list
- e1:e2 type checks when we have a type t such that el has type t
   and e2 has a type t list. then the result type is t list
- null : 'a list -> bool
- hd   : 'a list -> 'a
- tl   : 'a list -> 'a list

** let bindings
1 Syntax : let b1 b2 ... bn in e end

2 Type-checking
  - Type-check each bi and e in a static environment that includes
    the previous bindings.
    Type of the whole let-expression is the type of e.

3 Evaluation
  - Evaluate each bi and e in a dynamic environment that includes
    the previous bindings.
    Result of the whole let-expression is the result of evaluating e.

** Options
1 Syntax:  t option is a type for any type t

*** building
- NONE   - has type 'a optis on (much like [] has type 'a list
- SOME e - has type t option if e has type t (much like e::[])

*** Accessing
- isSome - has type 'a option -> bool
- valOf  - has type 'a option -> 'a  (exception if given NONE)
** Bigger types
- Base types: int bool unit char
- Compound types
*** Building blocks
- Each of - A val 't' contains values of each of t1 t2 ... tn
  tuples, records
- One of - A val 't' contains values of t1 t2 ... tn
  options, enums
- Self reference - A val 't' can refer to other t values
  lists contains an int 'and' another list 'or' it's empty
- nested compounds of these 
** Records
  - like tuples with named fields
Records values have fields (any name) holding values
  {f1 = v1, ..., fn = vn}
Record types have fields (and name) holding types
  {f1 : t1, ..., fn : tn}
Order of fields never matters - alphabetizes

Building records:
  {f1 = e1, ..., fn = en}
Accessing pieces:
  #myfieldname e

(Evaluation rules and type-checking as expected)

** By name vs. by position
*** Little difference (4,7,9) and {f=4, g=7, h=9}
-- Tuples are shorter
-- Records are easier to remember
-- Matter of taste

*** A common hybrid
-- Caller uses position
-- Callie uses variables
** Truth about tuples
- just syntax sugar for records
- (e1, ..., en) is the same as {1=e1, ..., n=en}
- t1 * ... * tn is the same as {1:t1, ..., n:tn}
- records with field names 1,2,...,n
** Datatype bindings
#+BEGIN_SRC sml
  datatype mytype = TwoInts of int * int
         | Str of string
         | Pizza
#+END_SRC

datatype t = C1 of t1 | C2 of t2 | ... | Cn of tn

*** Syntax
- Adds a new type 't' to the environment
- Add constructors to the environment of type ti -> t
  - A constructor is (among other things), a function that makes
    values of the new type

- Omit "of t" for constructors that are just tags, with no underlying data
  Such as Ci is a value of type 't'

- Use case expressions to see:
-- What variant (tag) it has
-- Extract the underlying data once you know the tag.

*** Evaluation
- Can use case expressions anywhere an expression can go.
-- Does not need to be whole function body, but often is

- Evaluate e to a value call it v

- if pi is the first pattern to match v, the result is evaluation of ei
  in environment "extended by the match"

- Pattern Ci (x1, ..., xn) matches value Ci(v1,...,vn) and extends
  the environment with x1 to v1 ... xn to vn
  - for "no data" constructors, pattern Ci matches value Ci

** Case Expressions
*** Example:
#+BEGIN_SRC sml
    fun f x =  (* f has type mytype -> int *)
      case x of
          Pizza => 3
        | TwoInts(i1,i2) => i1+i2
        | Str s => String.size s
#+END_SRC

** Patterns
- Syntax
#+BEGIN_SRC sml
  case e0 of
       p1 => e2
     | p2 => e2 
     | ...
     | pn => pn
#+END_SRC
-- Each pattern is a constructor name followed by the right
   number of variables
--- Syntactically most patterns look like expressions
--- But patterns are not expressions
    We don't evaluate them.
    We match them to e0.

** Type synonyms
- A datatype binding introduces a new type name
  - Distinct from existing types
  - Only way to create values is with constructors

- A type synonym is a new kind of binding
#+BEGIN_SRC smlg
type aname = t
#+END_SRC

 - Just creates another name for a type
 - Type and name are interchangeable in every way
 - REPL picks what it wants for naming.

** Options are data types
- NONE and SOME are constructors, not just functions
- So use pattern-matching not isSome and valOf
#+BEGIN_SRC sml
  fun inc_or_zero intoption =
    case intoption of
        NONE => 0
      | SOME i => i+1
#+END_SRC

** Lists are datatypes
- Do not use hd, tl, or null either
-- [] and :: are constructors too.
-- (strange syntax, particularly infix)

#+BEGIN_SRC sml
    fun sum_list xs =
      case xs of
          [] => 0
        | x::xs' => x + sum_list xs'

  fun append (xs,ys) =
    case xs of
        [] => ys
      | x::xs' => x :: append(xs', ys)
#+END_SRC
** Polymorphic datatypes
- int list, string list, int list list are types, not lists
- polymorphic functions
#+BEGIN_SRC sml
val sum_list : int list -> int
val append : 'a list * 'a list -> 'a list
#+END_SRC

*** Defining polymorphic datatypes
#+BEGIN_SRC sml

datatype 'a option = NONE | SOME of 'a

datatype 'a mylist = Empty | Cons of 'a * 'a mylist

datatype ('a,'b) tree =
         Node of 'a * ('a,'b) tree * ('a,'b) tree
      | Leaf of 'b

#+END_SRC

- Can use these type variables in constructor definitions

- Binding them introduces a type constructor, not a type
  - Must say int mylist of string or string mylist or 'a mylist not
    "plain" mylist
** Each of pattern matching
*** Pattern matching works of records and tuples
- The pattern (x1,..,xn) matches tuple value (v1,..,vn)
- The pattern {f1=x1, ..., fn=xn} matches
  the record value {f1=v1, ..., fn=vn} (fields can ve freordered)
*** Example
- poor style but works
#+BEGIN_SRC sml
  fun sum_triple triple =
    case triple of
        (x,y,z) => x + y + z

  fun full_name r =
    case r of
        {first=x, middle=y, last=z} =>
           x ^ " " ^ y ^ " " ^ z
#+END_SRC

*** Val-binding patterns
- val-bindings can use a pattern, not just a variable
   val p = e

- Great for getting (all) pieces out of an each-of type
  also can get only parts out

- Usually poor style to put a constructor pattern in a val-binding
  - Tests for the one variant and raises an exception if a different
    one is there (like hd, tl, and valof).

**** Better example
- This ok style
  - Though we will improve it again next
  - Semantically identical to one-branch case expressions
#+BEGIN_SRC sml
  fun sum_triple triple =
    let val (x, y, z) = triple
    in
        x + y + z
    end

   fun full_name r =
     let val {first=x, middle=y, last=z} = r
     in
         x ^ " " ^ y ^ " " ^ z
     end         
#+END_SRC

*** Best example
- A function argument can also be a pattern
  - Match against the argument in a function call
    fun f p = e
- Examples (great stype!):
#+BEGIN_SRC sml
  fun sum_triple (x, y, z) =
    x + y + z

  fun full_name {first=x, middle=y, last=z} =
    x ^ " " ^ y ^ " " ^ z
#+END_SRC
** A little type inference
- unexpected polymorphism
#+BEGIN_SRC sml
fun partial_sum (x, y, z) =
  x + y;

fun partial_name {first=x, middle=y, last=z} =
  x ^ " " ^ z;
#+END_SRC

For # deconstruction type declarations must be made
#+BEGIN_SRC sml
fun sum_triple2 (triple : int*int*int) = (* how many positions??? *)
  #1 triple + #2 triple + #3 triple;

fun full_name2 (r : {first:string, middle:string, last:string}) =
  #first r ^ " " ^ #middle r ^ " " ^ #last r;
#+END_SRC

Polymorphic funtions
BEGIN_SRC sml
(* partial_sum : int * 'a * int -> int *)
fun partial_sum (x, y, z) =
  x + z

(* partial_name : {first:string, last:string, middle:'a} -> string  *)
fun partial_anem {first=x, middle=y, last=z} =
  x ^ " " ^ z
#+END_SRC

** Equality types

#+BEGIN_SRC sml
(* ''a * ''b -> string  *)
fun same_thing (x, y) =
  if x=y then  "yes" else "no";

(* int -> string  *)
fun is_three x =
  if x=3 then "yes" else "no";
#+END_SRC

** Nested patterns
- patterns are recursive
#+BEGIN_SRC sml
(* do this - recursive patterns  *)
fun zip3 list_triple =
  case list_triple of
      ([],[],[]) => []
   | (hd1::tl1, hd2::tl2, hd3::tl3) => (hd1, hd2, hd3) :: zip3 (tl1, tl2, tl3)
   | _ => raise ListLengthMismatch;

(* the inverse  *)
fun unzip3 lst =
  case lst of
      [] => ([],[],[])
    | (a,b,c)::tl1 => let val (l1,l2,l3) = unzip3 tl1
                      in
                          (a::l1, b::l2, c::l3)
                      end;

(* more examples  *)

(* int list -> bool  *)
fun nondecreasing xs =
  case xs of
      []    => true
    | _::[] => true
    | head::(neck::rest) => head <= neck
                            andalso nondecreasing (neck::rest);

datatype sgn = P | N | Z

(* int * int -> sgn   *)
fun mulsign (x1,x2) =
  let
      fun sign x = if x=0 then Z else if x>0 then P else N
  in
      case (sign x1, sign x2) of
          (Z,_) => Z 
        | (_,Z) => Z
        | (P,P) => P
        | (N,N) => P
        | (N,P) => N
        | (P,N) => N
  end;
#+END_SRC

*** Nested patterns can lead to very elegant, concise code
- Avoid nested case expressions if nested patterns are simpler and
  avoid unnecessary branches of let-expressions
   example: unzip3 and nondecreasing
- A common idiom is matching against a tuple of datatypes to
  compare them
   example: zip3 and multsign

*** Wildcards are good style
- Use them instead of variables when you do not need the data
   example: len and multsign

*** Semantics
- if p is a variable x, the match succeeds and x is bound to v
- if p is _, the match succeeds and no bindings are introduced
- if p is (p1,...,pn) and v is (v1,...,vn) the match succeeds if and onlu if
  p1 matches v1,...,pn mathces vn. The bindings are the union of all bindings from
  the submatches.
- if p is C p1, the match succeeds if v is C v1 (ie, the same constructor) and p1
  matches v1. The bindings are the bindings from the submatches
- ...(there are several other similar forms of patterns)
