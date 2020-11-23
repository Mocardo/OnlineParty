using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sindico : MonoBehaviour
{
    public Text textoDeConectado;
    public Text textoDeBotao;
    public GameObject containerDeSalas;
    public GameObject prefabSala;
    public GameObject painelDeSalas;
    public GameObject canvas;
    public GameObject prefabDoPlayer;
    public Button deConectar;
    public Button deCriarSala;
    public Scrollbar scrollDasSalas;
    public Transform spawn;
    private RectTransform rt;


    // Start is called before the first frame update
    void Start()
    {
        rt = containerDeSalas.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.connected)
        {
            textoDeConectado.text = "Conectado";
            textoDeBotao.text = "Desconectar";

            listarSalas();
        }
        else
        {
            textoDeConectado.text = "Desconectado";
            textoDeBotao.text = "Conectar";
        }
    }

    int numAtualDeSalas = 0;
    int numAnteriordeSalas = 0;

    void listarSalas()
    {
        numAtualDeSalas = PhotonNetwork.GetRoomList().Length;
        numAtualDeSalas = PhotonNetwork.countOfRooms;

        if(numAtualDeSalas != numAnteriordeSalas)
        {
            for(int i=0;i<rt.childCount;i++)
            {
                Destroy(rt.GetChild(0));
            }

            if(PhotonNetwork.insideLobby)
            {
                insereSala(numAtualDeSalas);
                numAnteriordeSalas = PhotonNetwork.countOfRooms;
            }
        }

        numAnteriordeSalas = numAtualDeSalas;
    }
    void adapteContainer(int numSalas)
    {
        RectTransform T= ((GameObject) Instantiate (prefabSala, Vector3.zero, Quaternion.identity)).GetComponent<RectTransform>();
        T.parent = rt;
        T.localScale = new Vector3(1,1,1);

        T.offsetMax = Vector2.zero;
        T.offsetMin = Vector2.zero;

        rt.sizeDelta = new Vector2(0,numSalas*1.1f*T.rect.height);

        Destroy(T.gameObject);
    }

    void insereSala(int numSalas)
    {
        adapteContainer(numSalas);
        Text t;
        RoomInfo [] sala = PhotonNetwork.GetRoomList();
        for( int i=0; i<numSalas;i++)
        {
            RectTransform T= ((GameObject) Instantiate (prefabSala, Vector3.zero, Quaternion.identity)).GetComponent<RectTransform>();
            T.parent = rt;
            //t = T.GetChild(0).GetComponentInChildren<Text>();
            //t = (Text) sala[i].Name ;
            //t = T.GetChild(1).GetComponentInChildren<Text>();
           //t = sala[i].PlayerCount+" /"+sala[i].MaxPlayers;
           //t = (Text) sala[i].PlayerCount;
        }

        scrollDasSalas.value = 1;
    }

    void OnConnectedToPhoton()
    {
        containerDeSalas.SetActive(true);
        deCriarSala.gameObject.SetActive(true);
        deConectar.interactable = true;
        painelDeSalas.SetActive(true);
    }
    public void botaoConectar()
    {
        if(!PhotonNetwork.connected)
        {
            deConectar.interactable = false;
            PhotonNetwork.ConnectUsingSettings("1");
        }
        else
        {
            PhotonNetwork.Disconnect();
        }
    }

    public void criarSala()
    {
        PhotonNetwork.CreateRoom("umaSala", new RoomOptions() { MaxPlayers = 20}, null);
    }

    void OnCreatedRoom()
    {
        canvas.SetActive(false);
        PhotonNetwork.Instantiate("NPC2",spawn.position, Quaternion.identity,0);
        Debug.Log("A sala foi criada com sucesso");
    }

    void OnPhotonCreateRoomFailed()
    {
        Debug.Log("A criação da sala falhou");
    }
}
