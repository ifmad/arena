using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Text;
using System;

public class LoginClick : MonoBehaviour {
    UnityWebRequestAsyncOperation response;
    void Start() {
        transform.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(login);
    }
    private void Update() {
        if (response != null && response.isDone) {
            Debug.Log(response.webRequest.downloadHandler.text);
            response = null;//FIXME: code smell
        }

    }

    public void login() {
        UnityWebRequest request = UnityWebRequest.Get("localhost:8080");
        request.SetRequestHeader("Authorization", "Basic "+ Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:pass")));
        response = request.SendWebRequest();
        Debug.Log("login or something");
    }
}
