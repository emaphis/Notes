# notes for Calva - A Clojure environment for Visual Studio Code

## Calva - usage info

### Top ten commands

default keybinding         Action

ctrl+w                     Grow/expand selection

alt+ctrl+c enter           Load current file

alt+ctrl+c v               Evaluate current form

alt+ctrl+c space           Evaluate current top-level form

escape                     Dismiss the display of results

alt+ctrl+c ctrl+alt+e      evaluate the current form in the REPL window.

alt+ctrl+c ctrl+alt+space  to evaluate the current top-level form in this window

alt+ctrl+c ctrl+alt+n      Load current namespace in the REPL window

ctrl+alt+c p               Toggle pretty printing of results on and off

### Connecting to a projects

Default keybinding     Action

ctrl+alt+c ctrl+alt+j  Start a Project REPL and Connect (aka Jack-In)

ctrl+alt+c ctrl+alt+c  Connect to a Running REPL Server in the Project

ctrl+alt+c alt+c       Connect to a Running REPL Server, not in Project

calva.disconnect       Disconnect from the REPL Server

### REPL Commands

Default keybinding     Action

alt+up/down            Navigate history

alt+enter              Submit current line

ctrl+d                 Interrupt a running evaluated

ctrl+l                 Clear the REPL

### Running tests through the REPL connection, and mark them in the Problems tab 

Default keybinding  Action

ctrl+alt+c t        Run namespace tests

ctrl+alt+c shift+t  Run all tests

ctrl+alt+c ctrl+t   Rerun previously failing tests

Marks test failures using the Problem tab
User setting for running namespace tests on save (defaults to on)
Caveat: Right now the tests are reported only when all are run, making it painful to run all tests in larger projects.

### Code evaluation

Default keybinding  Action

ctrl-alt-c enter    Loading Current File and Dependencies

ctrl+alt+c e        Evaluate code at cursor and show the results as annotation in the editor

escape              Dismiss the display of results by pressing.a

ctrl+alt+c c        Evaluate code and add as comment

ctrl+alt+c r        Evaluate code and replace it in the editor, inline

ctrl+alt+c ctrl+c   Copy last evaluation results

ctrl+alt+c p        Pretty printing evaluation resuls

ctrl+alt+c spc      Evaluate current top level form (based on where the cursor is) and show results inline

### Integrated REPLs using the Terminal tab

Default keybinding     Action

ctrl+alt+c alt+spc     Send the current top level form to the REPL terminal

ctrl+alt+c ctrl+alt+n  Load current namespace in the REPL window

ctrl+alt+c ctrl+alt+v  Evaluate current editor form in the REPL window

ctrl+alt+c ctrl+space  Evaluate current editor top level form in the REPL window

ctrl+alt+c n        Switch to current namespace in the terminal REPL

ctrl+alt+c alt+n    Load current namespace in the terminal REPL

ctrl+alt+c alt+e    Evaluate code from the editor to the terminal REPL

ctrl+alt+c s        Selection of current form.

## Paredit - Commands

    Note: You can choose to disable all default key bindings by configuring calva.paredit.defaultKeyMap to none.

 (Then you probably also want to register your own shortcuts for the commands you often use.)

### Navigation

Default keybinding  Action

ctrl+right          Forward Sexp

ctrl+left           Backward Sexp

ctrl+down           Forward Down Sexp

ctrl+up             Backward Up Sexp

ctrl+alt+right      Close List

### Selecting

Default keybinding  Action

ctrl+w              Expand Selection

ctrl+shift+w        Shrink Selection

ctrl+alt+w space    Select Current Top Level Form

## Editing

Default keybinding  Action

ctrl+alt+.          Slurp Forward

ctrl+alt+<          Slurp Backward

ctrl+alt+,          Barf Forward

ctrl+alt+>          Barf Backward

ctrl+alt+s          Splice

ctrl+alt+shift+s    Split Sexp

ctrl+delete         Kill Sexp Forward

ctrl+shift+backspace (on Mac)   Kill Sexp Forward

ctrl+backspace      Kill Sexp Backward

ctrl+alt+down       Splice & Kill Forward

ctrl+alt+up         Splice & Kill Backward

ctrl+alt+(          Wrap Around ()

ctrl+alt+[          Wrap Around []

ctrl+alt+{          Wrap Around {}

ctrl+alt+i          Indent

backspace           Delete Backward, unless it will unbalance a form

delete              Delete Forward, unless it will unbalance a form

shift+backspace (on Mac)    Delete Forward, unless it will unbalance a form

ctrl+alt+backspace  Force Delete Backward

ctrl+alt+delete     Force Delete Forward

alt+shift+backspace (on Mac)    Force Delete Forward
---                 Transpose
NB: Strict mode is enabled by default. The backspace and delete keys won't let you remove parentheses or brackets so they become unbalanced. To force a delete anyway, use the supplied commands for that.
  
Strict mode can be switched off by by configuring calva.paredit.defaultKeyMap to original instead of strict.

(Actuallym currently strict mode is not enabled by default. There are some issues with it that needs to be ironed out first. But please help with testing by enabling it.)

### Copying/Yanking

Default keybinding   Action

ctrl+alt+c ctrl+rgt  Copy Forward Sexp

ctrl+alt+c ctrl+lft  Copy Backward Sexp

ctrl+alt+c ctrl+dwn  Copy Forward Down Sexp

ctrl+alt+c ctrl+up   Copy Backward Up Sexp

ctrl+alt+c ctrl+alt+rgt  Copy Close List

### Cutting

Default keybinding   Action

ctrl+alt+x ctrl+rgt  Cut Forward Sexp

ctrl+alt+x ctrl+lft  Cut Backward Sexp

ctrl+alt+x ctrl+dwn  Cut Forward Down Sexp

ctrl+alt+x ctrl+up   Cut Backward Up Sexp

ctrl+alt+x ctrl+alt+rgt  Cut Close List
