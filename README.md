# MemeManager

# WEBSITE PITCH + Website Functionality in Depth:
This website program is a website I call 'Memely'. Memely is a Meme hosting image site. It is an exclusive site however, and they only allow the best of the best uploads from users.

THe way Memely currently works are anonymous users can look at the meme gallery, contact info, home page. THey must log in to submit their Meme Vision. Users submit meme ideas with a Title and Genre. An Admin or Manager then approves or rejects their meme request. If approved, a user is allowed to upload their meme to the coveted Image Gallery.

# IMPORTANT DEFINITIONS:
Meme: an element of a culture or system of behavior that may be considered to be passed from one individual to another by nongenetic means, especially imitation.
a humorous image, video, piece of text, etc., that is copied (often with slight variations) and spread rapidly by Internet users.

# HOW TO USE:
Website utilizes authorization with a password that is stored using SecretManagerTools. If you do not have SecretManagerTools, the tutorial is linked here: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=visual-studio

After installing, and before starting up the program. YOu MUST go to command prompt and set your admin and manager password. Go to command prompt and go to the root (where startup.cs and program.cs are located). 

Type in this command: user-secrets set SetUserPW InsertPasswordHere
  
When you want to login as manager or admin on the website username is: admin@memes.com or manager@memes.com. Both with the same password that you set in the command above.

If you want to be a regular user, register as a regular user.

Admins can approve, reject, delete anyones post, edit anyones post.

Managers can approve,reject anyone but only delete their own.

Should be able to run the website now after password is set. Actual in depth description of website functionality is below Website Pitch:






