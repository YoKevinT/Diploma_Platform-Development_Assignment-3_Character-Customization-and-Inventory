using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.Networking;

#region Class
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
#endregion

public class Login : MonoBehaviour
{
    #region Variables

    //Create Account
    public InputField username;
    public InputField password;
    public InputField email;
    //Sign In
    public InputField usernameSignIn;
    public InputField passwordSignIn;
    //Create Code
    private string characters = "016789abciuvwxABCDEF";
    private string code = "";
    public string userNotFound;

    #endregion

    #region CreateUser

    IEnumerator CreateUser(string _username, string _email, string _password)
    {
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _username);
        form.AddField("email", _email);
        form.AddField("password", _password);
        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log("webRequest.error");
        }
        else
        {
            Debug.Log("Form uplad complete");
        }
    }

    public void CreateNewUser()
    {
        StartCoroutine(CreateUser(username.text, password.text, email.text));
    }

    #endregion

    #region UserLogin

    IEnumerator UserLogin(string usernameSignIn, string passwordSignIn)
    {
        string loginURL = "http://localhost/nsirpg/login.php";
        WWWForm form = new WWWForm();
        form.AddField("usernameSignIn", usernameSignIn);
        form.AddField("passwordSignIn", passwordSignIn);
        UnityWebRequest webRequest = UnityWebRequest.Post(loginURL, form);
        yield return webRequest.SendWebRequest();
        //Debug.Log(webRequest.downloadHandler.text);

        if (webRequest.downloadHandler.text == "Login Successful")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
            //Debug.Log("NOE");
        }
    }

    public void SubmitLogin()
    {
        StartCoroutine(UserLogin(usernameSignIn.text, passwordSignIn.text));
    }

    #endregion

    #region SendEmail

    public void SendEmail(string _email)
    {
        for (int i = 0; i < 20; i++)
        {
            int a = UnityEngine.Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(_email);
        mail.Subject = "Password Reset";
        mail.Body = "Hello " + "user" + "\nReset using this code: " + code;
        // Connect to Google
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        // Be able to send through ports
        smtpServer.Port = 25; //8080 80
        // Login to Google
        smtpServer.Credentials = new System.Net.NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };
        smtpServer.Send(mail);
        Debug.Log("Sending Email");
    }

    #endregion

    #region ForgotRequest

    IEnumerator ForgotRequest(string email)
    {
        string forgotURL = "http://localhost/nsirpg/checkemail.php";
        WWWForm form = new WWWForm();
        form.AddField("email_Post", email);
        UnityWebRequest webRequest = UnityWebRequest.Post(forgotURL, form);
        yield return webRequest.SendWebRequest();

        if (webRequest.downloadHandler.text == "User Not Found")
        {
            Debug.Log("ForgotEmail");
        }
        else
        {
            ForgotRequest(email);
        }
    }

    public void SubmitForgotRequest()
    {
        StartCoroutine(ForgotRequest(email.text));
    }

    #endregion

}