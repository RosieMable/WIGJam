//NiceGuy Dialogue
->NiceGuyIntro

== NiceGuyIntro ==
Hi there, nice to meet you!

+[Hey] -> Path1Start
+[Nice to meet you too!] ->Path2Start

==Path1Start==
Uhm, so how are you doing?
+[Going out soon, you?] ->Path1Cont
+[Not too bad thanks. Going out shortly, and yourself?] ->Path1Cont

== Path1Cont ==
Oh, I am good thanks, just glad there is someone finally replying on this site. How has your experience been here?

+[Eh, been alright, a few ppl asking nudes. You?] ->Path1ContNetural
+[Ah don`t get me started. Nigerian princes, rude a*holes asking nudes and stuff. What about you?] ->Path1ContFriendly

== Path1ContNetural ==
Oh, that`s not really nice. I get the occasional bots myself, or people just disappearing after a short while.
Hope you won`t be one of them, you seem like a cool person :)
+[Awh that`s nice of you to say :)] ->Path1ContNeutralRed
+[Thanks.] ->Path1ContNeutralRed


== Path1ContFriendly ==
Oh, sorry to hear that, don`t worry I won`t be asking nudes anytime soon :D 
+[Uhhh...] ->Path1ContFriendlyRed1
+[Thanks :)  That`s a relief.] ->->Path1ContFriendlyRed2


==Path1ContNeutralRed ==
I mean, it`s true ;) I just am afraid about saying something that might sound weird or idk.

+[Head out to the party...] ->Path1Disappear
+[haha, don`t worry.  But I gotta go now as I am late.] ->Path1End

== Path1ContFriendlyRed1 ==
Sorry, I was just joking, please don`t hate me...

+[Head out to the party...] ->Path1Disappear
+[haha, don`t worry.  But I gotta go now as I am late.] ->Path1End

== Path1ContFriendlyRed2 ==
Glad to hear it. I was afraid you might misunderstand the joke. I really wasn`t implying or anything.

+[Head out to the party...] ->Path1Disappear
+[haha, don`t worry.  But I gotta go now as I am late.] ->Path1End

== Path1Disappear ==
Uhm, hello, are you still there?

+[...] ->Path1DisappearCont1

== Path1DisappearCont1 ==
I am sorry if I offended you in any way, I was just honestly joking, can we start over again?

+[...] ->Path1DisappearCont2

== Path1DisappearCont2 ==
Alright. I understand, I never get anywhere with girls, they all just find someone else eventually.

+[...]->Path1DisappearEnd

== Path1DisappearEnd ==
Good luck I guess. If you ever change your mind tho do let me know, I think I am gonna be on this site for a long while.

->DONE

== Path1End ==
Oh, okay, hope we can continue chatting later. If you are still up for it of course.I`d understand if not tho, don`t worry.
 +[Yeah, uhm, sorry but I don`t think this would work out.] ->No
 +[Oh, sure. I will be a bit busy so I might not respond that often, but yeah, I`d like that :)] ->Yes
 
 == Path2Start ==
 So what are you up to?
 
 +[Heading out soon, you?] ->Path2Cont
 +[Working on some stuff from home, then heading out soon. You?] ->Path2Cont
 
 == Path2Cont ==
 Oh cool, with friends, family or?
 +[Friends] ->Path2Netural
 +[With some friends :) What are you gonna do?]->Path2Friendly
 
 == Path2Netural ==
 Oh nice. 
 +[...]->Path2NeturalCont1
 
 == Path2NeturalCont1 ==
 uhm, are you not really interested in chatting or busy?
 
 +[I am getting ready, I did say I am heading out soon.] ->Path2NeutralRed1
 +[Sorry, just getting ready quick. I am already late a little :)] ->Path2NeutralRed1
 
 == Path2NeutralRed1 ==
Oh okay, sorry i thought you already lost interest in me ahah.

+[...]->Path2NeutralEnd

== Path2NeutralEnd ==
But yeah, hope you are gonna have fun, but not too much without me ahah. Will I hear back from you later?

 +[Yeah, uhm, sorry but I don`t think this would work out.] ->No
 +[Oh, sure. I will be a bit busy so I might not respond that often, but yeah, I`d like that :)] ->Yes

== Path2Friendly ==
Idk, just probably gonna play something by myself. My friends are usually too busy going out. I rarely get invited, plus not doing that great on money atm.

+[...] ->Path2FriendlyCont

== Path2FriendlyCont ==
So is it just friends or you are interested in someone who you going out with?

+[That`s an odd question to ask] ->Path2FriendlyNeutral
+[Just friends. not really looking for anything serious atm ahah.] ->Path2FriendlyFriendly

== Path2FriendlyFriendly ==
Oh, right...

[...] ->Path2FriendlyEnd

== Path2FriendlyEnd ==
I thought you are looking for someone cause it did say on your profile looking for dates. You still interested in chatting though?

 +[Yeah, uhm, sorry but I don`t think this would work out.] ->No
 +[Oh, sure. I will be a bit busy so I might not respond that often, but yeah, I`d like that :)] ->Yes


== Path2FriendlyNeutral ==
Sorry, didn`t mean to sound nosy, just want to know if you`d be interested still in chatting, like if I made a good first impression.
[...]->Path2FriendlyNeutralEnd

== Path2FriendlyNeutralEnd ==
But would you like to continue interacting and maybe meet up at some point? :)

+[Yeah, uhm, sorry but I don`t think this would work out.] ->No
+[Oh, sure. I will be a bit busy so I might not respond that often, but yeah, I`d like that :)] ->Yes
== Yes ==
Sure that`s okay, I am glad you are giving me a chance, I promise you will not be disappointed. 

+[...]->YesCont1

== YesCont1 ==
Have a good night. Hope you will have fun, and don`t  end up finding someone else ahaha, just kidding :)
->DONE

== No ==
Oh, but why? Did I say or do something wrong or? Would you give me another chance like, after the party? Or are you going to meet someone special or something?

+[...] ->NoCont1

== NoCont1 ==
I would love to meet up in person to prove to you that I am a nice guy. I know we barely know each other and it may sound creepy, but I promise I am a good person.

->DONE