-> main

=== main ===
A man in ragged clothing stands before you.
"Please spare some gold Sire, I cannot afford food."
    + [Gold]
        -> something("gold")
    + [Nothing]
        -> nothing("the finger")
        
=== something(stuff) ===
You gave him {stuff}.
This bro is gunna go buy a sandwich now.
-> END

=== nothing(nada) ===
You gave him {nada}!
Homedude is going to starve now.
-> END