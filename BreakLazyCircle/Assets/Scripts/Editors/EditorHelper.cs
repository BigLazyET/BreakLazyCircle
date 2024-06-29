using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Sprites;
using UnityEditor.U2D;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class EditorHelper : MonoBehaviour
{
    [System.Obsolete("This method is obsolete. Use NewSliceSprites instead.")]
    [MenuItem("EditorHelper/SliceSprites")]
    static void SliceSprites()
    {
        // Change the below for the with and height dimensions of each sprite within the spritesheets
        int sliceWidth = 64;
        int sliceHeight = 64;

        // Change the below for the path to the folder containing the sprite sheets (warning: not tested on folders containing anything other than just spritesheets!)
        // Ensure the folder is within 'Assets/Resources/' (the below example folder's full path within the project is 'Assets/Resources/ToSlice')
        string folderPath = "ToSlice";

        Object[] spriteSheets = Resources.LoadAll(folderPath, typeof(Texture2D));
        Debug.Log("spriteSheets.Length: " + spriteSheets.Length);

        for (int z = 0; z < spriteSheets.Length; z++)
        {
            Debug.Log("z: " + z + " spriteSheets[z]: " + spriteSheets[z]);

            string path = AssetDatabase.GetAssetPath(spriteSheets[z]);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.isReadable = true;
            ti.spriteImportMode = SpriteImportMode.Multiple;

            List<SpriteMetaData> newData = new List<SpriteMetaData>();

            Texture2D spriteSheet = spriteSheets[z] as Texture2D;

            for (int i = 0; i < spriteSheet.width; i += sliceWidth)
            {
                for (int j = spriteSheet.height; j > 0; j -= sliceHeight)
                {
                    SpriteMetaData smd = new SpriteMetaData();
                    smd.pivot = new Vector2(0.5f, 0.5f);
                    smd.alignment = 9;
                    smd.name = (spriteSheet.height - j) / sliceHeight + ", " + i / sliceWidth;
                    smd.rect = new Rect(i, j - sliceHeight, sliceWidth, sliceHeight);

                    newData.Add(smd);
                }
            }
            
            ti.spritesheet = newData.ToArray();
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }
        Debug.Log("Done Slicing!");
    }

    [MenuItem("EditorHelper/NewSliceSprites")]
    static void NewSliceSprites()
    {
        // Change the below for the with and height dimensions of each sprite within the spritesheets
        int sliceWidth = 64;
        int sliceHeight = 64;

        // Change the below for the path to the folder containing the sprite sheets (warning: not tested on folders containing anything other than just spritesheets!)
        // Ensure the folder is within 'Assets/Resources/' (the below example folder's full path within the project is 'Assets/Resources/ToSlice')
        string folderPath = "ToSlice";

        Object[] spriteSheets = Resources.LoadAll(folderPath, typeof(Texture2D));
        Debug.Log("spriteSheets.Length: " + spriteSheets.Length);

        for (int z = 0; z < spriteSheets.Length; z++)
        {
            var spriteSheet = spriteSheets[z] as Texture2D;
            Debug.Log("z: " + z + " spriteSheets[z]: " + spriteSheet);

            string path = AssetDatabase.GetAssetPath(spriteSheet);
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (textureImporter == null)
            {
                continue;
            }
            // 确保TextureImporter是Sprite类型
            textureImporter.isReadable = true;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;

            // 应用更改并重新导入
            EditorUtility.SetDirty(textureImporter);
            textureImporter.SaveAndReimport();

            // 获取 ISpriteEditorDataProvider
            var dataProvider = GetSpriteEditorDataProvider(textureImporter);
            if (dataProvider == null)
            {
                continue;
            }
            dataProvider.InitSpriteEditorDataProvider();

            // 创建新的精灵元数据列表
            List<SpriteRect> newSpriteRects = new List<SpriteRect>();

            for (int i = 0; i < spriteSheet.width; i += sliceWidth)
            {
                for (int j = spriteSheet.height; j > 0; j -= sliceHeight)
                {
                    var newSpriteRect = new SpriteRect
                    {
                        name = (spriteSheet.height - j) / sliceHeight + ", " + i / sliceWidth,
                        rect = new Rect(i, j - sliceHeight, sliceWidth, sliceHeight),
                        alignment = SpriteAlignment.Custom,
                        pivot = new Vector2(0.5f, 0.5f),
                        //border = new Vector4(0, 0, 0, 0)
                    };

                    newSpriteRects.Add(newSpriteRect);
                }
            }

            // 将新数据应用到精灵元数据
            dataProvider.SetSpriteRects(newSpriteRects.ToArray());
            EditorUtility.SetDirty(textureImporter);
            textureImporter.SaveAndReimport();
            //AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }
        Debug.Log("Done Slicing!");
    }

    static ISpriteEditorDataProvider GetSpriteEditorDataProvider(TextureImporter textureImporter)
    {
        var dataProviderFactories = new SpriteDataProviderFactories();
        dataProviderFactories.Init();
        return dataProviderFactories.GetSpriteEditorDataProviderFromObject(textureImporter);
    }
}
