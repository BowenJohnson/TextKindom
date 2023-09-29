INCLUDE Globals.ink

VAR version = 0 
~ version = RANDOM(1,3)

-> main

=== main ===
A man in ragged clothing stands before you.

{ version:
- 1: ->general
- 2: ->family
- 3: ->dog
}


=== general ===
Please spare some gold Sire, I cannot afford food.
    ->choices

== family ===
I cannot support my family, please spare some coins for us.
    ->choices


== dog ===
My dog will surely starve if I can't find some money, please help mi'liege.
    * [Offer 3 gold]
        How coud I possibly say no to a dog in need.
        ->accept
    * [Decline]
        ->decline


=== accept ===
~ gold = (gold - 3)
~ publicOpinion = ( publicOpinion + 1)
You gave him 3 gold.
Thank you sire! I will tell everyone in town of your generocity today.
-> END

=== decline ===
I'm affraid the court has higher priorities today.
The beggar is escourted out with a hopeless expression on his face.
-> END

=== military_service ===
What if instead I offer you a job in the military? If you join you'll earn a decent wage and I'll give you 3 gold as a sign on bonus right now?
    ->service_respose

=== conscript ===
~ publicOpinion = ( publicOpinion - 1)
~ soldiers = (soldiers + 1)
You want money you will have to earn it and I have just the job in mind.
Take him to the barracks and inform the captain of his new recruit.
Wait! Sire! You can't! The beggar cries as the guards drag him out of the room.
-> END

=== choices ===
* [Offer 3 gold]
    -> accept
* [Decline]
    -> decline
* [Offer Military Service]
    ->military_service
* [Conscript Into Military Service]
    ->conscript
    
=== service_respose ===
VAR choice = 0 
~ choice = RANDOM(1,2)

{choice == 1:->service_choice_1|->service_choice_2}


=== service_choice_1 ===
~soldiers = (soldiers + 1)
A chance to earn an honest living? I'll take it sire! It'll be an honor to serve!
The beggar is escourted out with the look of a man with a new lease on life.
-> END

=== service_choice_2 ===
I'm afraid I am unfit to serve sire, so I must decline.
The beggar is escourted out looking rather dejected.
-> END


