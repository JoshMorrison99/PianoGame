using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupModel
{
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}

public class SignupModelError
{
    public SignupModelErrorData error { get; set; }
}

public class SignupModelErrorData
{
    public string usernameError { get; set; }
    public string emailError { get; set; }
    public string passwordError { get; set; }
}

