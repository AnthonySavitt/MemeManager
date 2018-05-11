# MemeManager
IMPORANT PRE-NOTE: README COntains 2 parts. 1st part is functionality/how to run. 2nd Part are my challenges I faced during my development.

# IMPORTANT INFORMATION, READ THOUROUHGLY.:


# HOW TO USE:
Website utilizes authorization with a password that is stored using SecretManagerTools. If you do not have SecretManagerTools, the tutorial is linked here: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=visual-studio

After installing, and before starting up the program. YOu MUST go to command prompt and set your admin and manager password. Go to command prompt and go to the root (where startup.cs and program.cs are located). 

Type in this command: user-secrets set SetUserPW InsertPasswordHere
  
When you want to login as manager or admin on the website username is: admin@memes.com or manager@memes.com. Both with the same password that you set in the command above.

If you want to be a regular user, register as a regular user.

Admins can approve, reject, delete anyones post, edit anyones post.

Managers can approve,reject anyone but only delete their own.

Should be able to run the website now after password is set. Actual in depth description of website functionality is below Website Pitch:

# WEBSITE PITCH + Website Functionality in Depth:
This website program is a website I call 'Memely'. Memely is a Meme hosting image site. It is an exclusive site however, and they only allow the best of the best uploads from users.

THe way Memely currently works are anonymous users can look at the meme gallery, contact info, home page. THey must log in to submit their Meme Vision. Users submit meme ideas with a Title and Genre. An Admin or Manager then approves or rejects their meme request. If approved, a user is allowed to upload their meme to the coveted Image Gallery.


Memely does work the way it says in the website Pitch but technically speaking while it does what it says, has user authorization, it is not perfect and only approves the 'conceptt'. After approval, a user gains the link to open the file uploader and from there could theoretically upload whatever he or she wants. Never got it to work a different way. 

ALso had lots of trouble with normalization. Was not able to get it the way I wanted and ran out of time. 


# TLDR of my struggles throughout the week:
I constantly faced 502.5 error and many other little errors in development that i felt were not clear. The biggest problem I had with this is that razor pages has very limited resources at the moment due to its infancy. While it is very intutitive and there is al ot I like about it, it is not easy to look up solutions to problems. My original project idea was a lot more grandoise but realizing over the week my limitations we ended up with what we have. But you gotta give me some credit I Implemented an image galerry, authoirzation, I even made my own nice banners. 

# IMPORTANT DEFINITIONS:
Meme: an element of a culture or system of behavior that may be considered to be passed from one individual to another by nongenetic means, especially imitation.
a humorous image, video, piece of text, etc., that is copied (often with slight variations) and spread rapidly by Internet users.

# Sources where I took code and or learned from:
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=visual-studio
https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-2.1
https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages/?view=aspnetcore-2.1&tabs=visual-studio
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-2.1
https://stackoverflow.com/questions/34482323/asp-net-razor-page-dropdown-list?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
https://medium.com/@dreyescairo/create-a-simple-photo-gallery-app-using-asp-net-9d7aed97ce16


# Play by Play of the Development PRocess in My Thoughts if you're looking to go DEEP:
Timeline/Challenges Difficulties for this Project:
Starting on last Thursday I finally had time to start to project. Unfortunately the world is cruel like that. I spent a large portion of the time going through each of the tutorials linked and kept running it walls. Frequently encountering a 502.5 Error. Which plagued me for many days. I
I basically wanted to try to figure it out all out before starting and ended up just reaching a wall at every way. Ultimately I decided I needed to start one way or another.

I officially started by following the EF tutorial in the context of my MemeDatabase as much as I could, utilizing CRUD, developing a search function, and paginated lists much like the tutorial.

I decided to go back to Authorization, something demanded of the project. I went back to the tutorial I sought originally in attempt to figure out the 502.5 Error I was getting. I couldn’t find anything that worked online, I emailed you, and still couldn’t remove this wall. In a last ditch effort I opened a thread on the tutorial itself and Rick Anderson, the MS Employee who wrote that .NET Tutorials amongst most of the others, helped me with my problem and I got the tutorial to work!

At this point I attempted to incorporate the Authorization tutorial into the context of my project now that I knew how that one was working, however I ran into many walls along the way. And still have some (as of writing this).
At first the way I had developed using the tutorial, I had 2 Databases and 2 contexts when trying to incorporate the tutorial. As the Authorization tutorial utilized the ApplicationDbContext and I had created a new context, ‘MemeContext’ as per EF tutorials you linked.

This mix in databases led too confusing for me after way too many hours I decided to merge these databases, removing my MemeContext and making ApplicationDbContext handle everything. This worked and seemed I was on the right track to authorization with the rest of my stuff.

However the way the tutorial worked and my limited knowledge, I ran into errors towards the end relating to the way it was developed and my currently implemented PaginatedLists. At this current time I am at a loss. The error I get talks about it cannot convert GenericList to PaginatedList type. It says there an explicit cast but I have not found one online that works for my context. Bene stuck on this or other related problems trying to fix this for several hours now. Conisdering restarting my entire project, but starting from following the Authorization route first, as that is more important than Pagination in order to fulfill the requirements. 
11:24pm 5/9/18 report in: Restarting and starting with authorization is a good move. IT helped going for the more complicated move first before adding the tiny stuff again. Currently Have Authorization working with 3 classes of users with various things they can do. Following I re-implemented search and sorting. However…proving to have trouble with Pagination based on the way Authorization was implemented from the tutorial I followed. (All Tutorials Linked Below). Currently at the problem of not being able to have a 2nd list called ‘PaginatedList’ of the same object reference as being used for the List for Authorization. Will try to work on this for a bit more but if I can’t figure it out will go on to something more important.
11:46pm 5/9/18: Giving up on PaginatedLists at least for now. Going to attempt to figure out how to let user upload an image now. 
12:40AM 5/10/2018: Something that frustrates me with Razor Pages is because of how new it is, it is hard to find resources for it. MVC is everywhere and if you search up ‘how to do X’ with MVC, chances are you can find it. Razor Pages it is not as easy. Currently having a hell of a time trying to figure out how to let the user upload an image in the ‘Movie’ Model without having to create an entirely new model. One of the razor pages tutorials has one for text upload but it involves multiple models and I only want it in one in order to be displayed and accessed in the ‘create page’
1:50AM 5/10/2018: After digging through deep google searches I found a blog with a really clean implementation of a photo gallery. (Again referenced below) I implemented it into my website. Not sure yet how to tie it into my ‘Create Page’ but it is a nice start. Added some more models and implementation but no real normalization yet. Trying to figure out how to tie it all together now.
2:30AM 5/10/2018: Still unsure how to delete images from the gallery. Even through azure…When I ‘delete’ them from the blob it doesn’t go away from the website. Hmm
3:07AM 5/10/2018: Decided in the mean time to have it so only a manager or user can upload an image to the gallery. Perhaps if I can’t figure out how to apply authorization for users for uploading to the gallery, I will make it a Meme ‘suggestions’ page that will be utilized. If an admin/manager likes your meme suggestion, they will approve it and work on uploading your meme to the database.

3:53AM 5/10/2018: trying to get it so if a user suggestion gets approved, they gain access to the link to be able to upload the image. 

@if ((await AuthorizationService.AuthorizeAsync(User,item,MemeOperations.Approve)).Succeeded)
                    {
                        <a asp-page="./Delete" asp-route-id="@item.Id">Fuck you</a>

                    }

Unfortunately this is not working for some reason…

4:21AM: Figured out a similar way based on the previous Delete function approval. I check the item.status to see if it’s approved to get it to work and open up a link.
2 problems with this though is no security for the user. Once they are approved, they currently can upload as much as they like and no restriction on what they upload. Currently an honesty system lol. Not ideal for a real website but I’m almost at my limit for tonight.

4:48AM: Got a dropdown system for genre. Only the highest tiers of memes here. Figured out how to delete from images. IT was easy but just tired.
4:59AM:Going to bed for awhile. Plan for tomorrow (later today):
-Work on Website Aesthetics
-Learn to publish to Azure
-Learn to public to github
-develop foreign key table relations between gallery image and meme. Somehow relate data in some fashion. 
-Maybe create an information tab about each genre of Meme allowed. Aesthetic? 

4:50PM: Been oddly having troubles getting bootstrap to work without messing up my site. Added some different. Been trying for awhile to get a thumbnail of their uploaded image displayed in the ‘Meme Suggestion’ section but currently does not work.

I connected the GalleryImage Table to my Meme Table but it has proven not to work for displaying the  thumbnail. Not sure, a shame I figured it would work. At least it shows a blank thumbnail, shows I’m trying.
Gallery Image Table utilizes the creation of an ‘Azure Blob’. This led me to problem later on


6:19pm, Trying to Create a ‘KnowYourMeme’ Model which will hold a description for each of the ‘Genres’ I the Meme table. Unfortunatley getting the 502.5  Error that has plagued me many times during and can’t figure out why this time. Don’t have a MS employee in my back pocket this time. Going to avoid normalization for now to get it working before time limit is up…

7:20 Implemented some sweet new banners. Scaffoled for a new KnowYourMeme Model but realizing I am running out of time (have other errands tonight). Going to do a really rough Meme Trends Page
8:26pm implemented a trending meme page. It is purely visual sadly. I am out of time and was not able to utilize my scaffolded model to properly connect it to to the ‘Meme’ Model to have all my data seamlessly tie together. I do like this website though and actually hope to continue development beyond this class to continue to fix these shortcomings. 
11:00pm realized after uploading to github the way I had implemented my AzureBlob does not work for other people. Had to resort to local seeding for the gallery and utilized URI like an idiot but I am out of time. IT works but the SeedData.cs is MASSIVE. IT will load, just takes some time.


