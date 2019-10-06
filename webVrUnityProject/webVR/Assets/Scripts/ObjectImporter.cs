using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PolyToolkit;
using System;

namespace PolyToolkit
{
    public class ObjectImporter : MonoBehaviour
    {
        public GameObject addObjectButtonPrefab;
        public GameObject objectListHolder;
        public string keyword;
        /*
        private void Start()
        {
            ListAssets();
        }
        void ListAssets()
        {
            PolyListAssetsRequest req = new PolyListAssetsRequest();
            // Search by keyword:
            req.keywords = keyword;
            // Only curated assets:
            req.curated = true;
            // Limit complexity to medium.
            req.maxComplexity = PolyMaxComplexityFilter.MEDIUM;
            // Only Blocks objects.
            req.formatFilter = PolyFormatFilter.BLOCKS;
            // Order from best to worst.
            req.orderBy = PolyOrderBy.BEST;
            // Up to 20 results per page.
            req.pageSize = 10;
            PolyApi.ListAssets(req, MyCallback);
            void MyCallback(PolyStatusOr<PolyListAssetsResult> result)
            {
                if (!result.Ok)
                {
                    // Handle error.
                    return;
                }
                // Success. result.Value is a PolyListAssetsResult and
                // result.Value.assets is a list of PolyAssets.
                foreach (PolyAsset asset in result.Value.assets)
                {
                    PolyAddButton b = Instantiate(addObjectButtonPrefab, objectListHolder.transform).GetComponent<PolyAddButton>();
                    b.text.text = asset.displayName;
                    PolyApi.FetchThumbnail(asset, Callback);
                    void Callback(PolyAsset a, PolyStatus status)
                    {
                        if (!status.ok)
                        {
                            // Handle error;
                            return;
                        }
                        b.rawImage.texture = a.thumbnailTexture;
                    }

                    b.myAsset = asset;

                    // Do something with the asset here.
                }
            }
        }

        public void SearchModel(string key)
        {
            keyword = key;
            foreach (PolyAddButton b in objectListHolder.GetComponentsInChildren<PolyAddButton>())
            {
                Destroy(b.gameObject);
            }
            ListAssets();
        }
        public static void UploadObject(PolyAsset asset)
        {
            if (PhotonRoom.room == null)
            {
                DownloadObject(asset.name);
            }
            else
            {
                PhotonRoom.room.UploadObject(asset.name);
            }
        }

        public static void DownloadObject(string assetID)
        {
            PolyApi.GetAsset(assetID, MyCallback);
            void MyCallback(PolyStatusOr<PolyAsset> result)
            {
                if (!result.Ok)
                {
                    // Handle error.
                    return;
                }
                // Success. result.Value is a PolyAsset
                // Do something with the asset here.
                PolyApi.Import(result.Value, PolyImportOptions.Default(), InstantiateModel);
                void InstantiateModel(PolyAsset asset, PolyStatusOr<PolyImportResult> r)
                {
                    Instantiate(r.Value.gameObject);
                }
            }
        }


    }
    */
    }
}
