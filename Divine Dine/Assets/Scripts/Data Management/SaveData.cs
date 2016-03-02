using UnityEngine;    // For Debug.Log, etc.
using System.Collections;

using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;

// === This is the info container class ===
[Serializable ()]
public class SaveData : ISerializable {
	
	// === Values ===
	// Edit these during gameplay
	//public bool tile1;
	public string[] tileMaterials = new string[382]; // added one so we can start at index 1
	public string[] tileObjects = new string[382];
	public Quaternion[] objectRotations = new Quaternion[382];
	public int experience;
	public int money;
	// === /Values ===
	
	// The default constructor. Included for when we call it during Save() and Load()
	public SaveData () {}
	
	// This constructor is called automatically by the parent class, ISerializable
	// We get to custom-implement the serialization process here
	public SaveData (SerializationInfo info, StreamingContext ctxt)
	{
		// Get the values from info and assign them to the appropriate properties. Make sure to cast each variable.
		// Do this for each var defined in the Values section above
		for (int i = 1; i <382; i++) 
		{
			tileMaterials[i] = (string)info.GetValue("tileMaterial" + i, typeof(string));
			tileObjects[i] = (string)info.GetValue("tileObject" + i, typeof(string));
			objectRotations[i] = (Quaternion)info.GetValue("objectRotation" + i, typeof(Quaternion));
		}
		
		experience = (int)info.GetValue("levelReached", typeof(int));
		money = (int)info.GetValue ("Money", typeof(int));
	}
	
	// Required by the ISerializable class to be properly serialized. This is called automatically
	public void GetObjectData (SerializationInfo info, StreamingContext ctxt)
	{
		// Repeat this for each var defined in the Values section
		for (int i =1; i < 382; i++) 
		{
			info.AddValue("tileMaterial" + i, tileMaterials[i]);
			info.AddValue("tileObject" + i, tileObjects[i]);
			info.AddValue("objectRotation" + i, objectRotations[i]);
		}
		info.AddValue("levelReached", experience);
		info.AddValue ("Money", money);
	}
}

// === This is the class that will be accessed from scripts ===
public class SaveLoad{
	
	public static string currentFilePath = "SaveData.dd";    // Edit this for different save files
	
	// Call this to write data
	/*public static void Save ()  // Overloaded
	{
		Save (currentFilePath);
	}*/
	public static void Save (string filePath, SaveData data)
	{
		//SaveData data = new SaveData ();
		
		Stream stream = File.Open(filePath, FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		bformatter.Serialize(stream, data);
		stream.Close();
	}
	
	// Call this to load from a file into "data"
	//public static void Load ()  { Load(currentFilePath);  }   // Overloaded
	public static SaveData Load (string filePath) 
	{
		SaveData data = new SaveData ();
		Stream stream = File.Open(filePath, FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		data = (SaveData)bformatter.Deserialize(stream);
		stream.Close();

		return data;
	}
	
}

// === This is required to guarantee a fixed serialization assembly name, which Unity likes to randomize on each compile
// Do not change this
public sealed class VersionDeserializationBinder : SerializationBinder 
{ 
	public override Type BindToType( string assemblyName, string typeName )
	{ 
		if ( !string.IsNullOrEmpty( assemblyName ) && !string.IsNullOrEmpty( typeName ) ) 
		{ 
			Type typeToDeserialize = null; 
			
			assemblyName = Assembly.GetExecutingAssembly().FullName; 
			
			// The following line of code returns the type. 
			typeToDeserialize = Type.GetType( String.Format( "{0}, {1}", typeName, assemblyName ) ); 
			
			return typeToDeserialize; 
		} 
		
		return null; 
	} 
}