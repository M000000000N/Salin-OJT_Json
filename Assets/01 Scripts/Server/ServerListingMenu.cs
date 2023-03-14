using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerListingMenu : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ServerListing serverListing;
    private List<ServerListing> listings = new List<ServerListing>();

    [SerializeField] Network network;

    void Start()
    {
        if (network != null)
            GetCurrentServerList();
    }

    private void GetCurrentServerList()
    {
        for (int i = 0; i < network.Data.rows.Count; i++)
        {
            AddServerListing(network.Data.rows[i]);
        }
    }

    private void AddServerListing(Network.ServerDto ServerDto)
    {
        ServerListing listing = Instantiate(serverListing, content);

        if (listing != null)
        {
            listing.SetServerName(ServerDto);
            listings.Add(listing);
        }
    }
}
