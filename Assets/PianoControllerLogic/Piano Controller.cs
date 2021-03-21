// GENERATED AUTOMATICALLY FROM 'Assets/PianoControllerLogic/Piano Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PianoController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PianoController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Piano Controller"",
    ""maps"": [
        {
            ""name"": ""Piano"",
            ""id"": ""924d268d-2de1-4314-947c-6b992ddd54bc"",
            ""actions"": [
                {
                    ""name"": ""Piano Action"",
                    ""type"": ""Button"",
                    ""id"": ""4f98c893-56ae-4c7a-9934-dc27313d1a20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8cd2bcd7-8b54-45ea-9daa-b70325d9aca3"",
                    ""path"": ""<MidiDevice>/note000"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e4603f2-2b3e-406f-8229-920cf02b1c99"",
                    ""path"": ""<MidiDevice>/note001"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bbc7dec-0e00-4562-b618-59c12e2350f8"",
                    ""path"": ""<MidiDevice>/note002"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fda3268-bfa6-40b6-b4f0-4c6376abc0c7"",
                    ""path"": ""<MidiDevice>/note003"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d40182f-1abc-417e-8280-8591d5c8f9e3"",
                    ""path"": ""<MidiDevice>/note004"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""767c02a3-80c3-4e0c-8b9e-8b5771091f98"",
                    ""path"": ""<MidiDevice>/note005"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d2b4e98-1f7f-435c-8814-7fff078214de"",
                    ""path"": ""<MidiDevice>/note006"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfbcd3b2-9384-47c0-a141-e16246c54661"",
                    ""path"": ""<MidiDevice>/note007"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0dcdfea-10fa-4307-80d0-a922de171ea7"",
                    ""path"": ""<MidiDevice>/note008"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c8d5229-15f9-4a1b-a239-2eaee173b4ae"",
                    ""path"": ""<MidiDevice>/note009"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ef5e6f9-8056-4eb5-8fbe-bf7c2f7e3fe0"",
                    ""path"": ""<MidiDevice>/note010"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2253f113-bc33-47d7-afc1-110f3bce22dc"",
                    ""path"": ""<MidiDevice>/note011"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86ae3b8f-8ff1-46e3-9543-51624ac2b274"",
                    ""path"": ""<MidiDevice>/note012"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8023570-d933-4cb3-b386-9c1157c5f5ad"",
                    ""path"": ""<MidiDevice>/note013"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fc4b860-6289-480d-afa7-2256da59398c"",
                    ""path"": ""<MidiDevice>/note013"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""156d61aa-741f-4117-8e96-d243aaac7352"",
                    ""path"": ""<MidiDevice>/note014"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""923a2a7e-dfa2-412a-86b1-5aa1e63d2820"",
                    ""path"": ""<MidiDevice>/note015"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a765d84-af89-4bae-b8bd-c10139c093f6"",
                    ""path"": ""<MidiDevice>/note016"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eeb2404-353e-477b-8821-d4c3e5b0b551"",
                    ""path"": ""<MidiDevice>/note017"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d554b23-2e50-4db7-a977-e57ea0b4e510"",
                    ""path"": ""<MidiDevice>/note018"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""534c0234-b069-41b4-af42-d49988ecf29e"",
                    ""path"": ""<MidiDevice>/note019"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""763e283f-3c2e-43b9-82e0-26a4ee3b3452"",
                    ""path"": ""<MidiDevice>/note020"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee39d8a-1e56-4360-924c-8e648f38d2f8"",
                    ""path"": ""<MidiDevice>/note021"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a46de27-8d03-42a4-aedf-1d85cd92f6f7"",
                    ""path"": ""<MidiDevice>/note022"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fecffbc9-575f-47ba-8f91-5959fda5a9c5"",
                    ""path"": ""<MidiDevice>/note023"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""001525bd-5309-4a57-8db7-036497c6ab86"",
                    ""path"": ""<MidiDevice>/note024"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""883e88ac-f915-4fc6-9037-2e18f8dc92ad"",
                    ""path"": ""<MidiDevice>/note025"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4aa2040c-3264-443c-a35a-25033c39efe5"",
                    ""path"": ""<MidiDevice>/note026"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cddbbde3-bdc2-4b05-9e3d-562f41ec92ec"",
                    ""path"": ""<MidiDevice>/note027"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""363b16c5-1210-42b8-a266-8703a6456d3d"",
                    ""path"": ""<MidiDevice>/note028"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d00549ea-7639-48fb-8f75-fa1ec70f0e42"",
                    ""path"": ""<MidiDevice>/note029"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64b6213d-b9db-4c39-b32d-e0a3ac5fdbb7"",
                    ""path"": ""<MidiDevice>/note030"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3acb3bcd-bc6f-408d-b361-daf100d77330"",
                    ""path"": ""<MidiDevice>/note031"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91081e07-f8f3-450e-a2a5-e3d193e5fb3a"",
                    ""path"": ""<MidiDevice>/note032"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9aef3851-f5b6-4ac1-bb7e-d78fc5001289"",
                    ""path"": ""<MidiDevice>/note033"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2b145d2-e5d2-4b68-ba6b-91d7eda18601"",
                    ""path"": ""<MidiDevice>/note034"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""668f6226-fd6c-4616-8464-1092906c8f1f"",
                    ""path"": ""<MidiDevice>/note035"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de87a0ee-6550-46b0-8d09-ad12bee91232"",
                    ""path"": ""<MidiDevice>/note036"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec4da4dc-10b4-454a-9e20-a16298e87c81"",
                    ""path"": ""<MidiDevice>/note037"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08e12c41-0d2f-45cb-af16-4fed0673d763"",
                    ""path"": ""<MidiDevice>/note038"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b9c240-02b1-4ecf-939b-a59f4ea9e1b9"",
                    ""path"": ""<MidiDevice>/note039"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c718f460-5591-4a27-a60e-8bfcfa770176"",
                    ""path"": ""<MidiDevice>/note040"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8126b5ec-56d3-440b-9113-005f8e4a45c2"",
                    ""path"": ""<MidiDevice>/note041"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c62957d-0257-46d9-87c9-f4f8bbba75f0"",
                    ""path"": ""<MidiDevice>/note042"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892c7244-5a44-4c6b-a7cf-9a4bf205bf69"",
                    ""path"": ""<MidiDevice>/note043"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31b53ca8-a798-4743-98e1-9283c02d3a92"",
                    ""path"": ""<MidiDevice>/note044"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6378a16-99ba-4b83-87dd-f5fc553ad229"",
                    ""path"": ""<MidiDevice>/note045"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8386626c-f09e-45d1-9177-6c7d5573608e"",
                    ""path"": ""<MidiDevice>/note046"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d40710f3-f823-4e7f-9f43-63af7f42f3fe"",
                    ""path"": ""<MidiDevice>/note047"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30ae779b-d062-4495-8df4-e69fca050320"",
                    ""path"": ""<MidiDevice>/note048"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""474ed4c2-a9c4-4e20-9790-3abd5ca10eb6"",
                    ""path"": ""<MidiDevice>/note049"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9abb230e-2fa3-4365-aa15-47cab852ee63"",
                    ""path"": ""<MidiDevice>/note050"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae5eb7e4-57e9-43b1-a09b-5f8586432eec"",
                    ""path"": ""<MidiDevice>/note063"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a018b3a-ccb7-4ea6-bde9-c7c05b586d8b"",
                    ""path"": ""<MidiDevice>/note052"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5888337-187c-4c5a-88ec-ab0b62016753"",
                    ""path"": ""<MidiDevice>/note053"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46c90fc5-6271-4523-8507-189fd2716585"",
                    ""path"": ""<MidiDevice>/note054"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed7051da-3129-4ee8-80c7-3ba628f2e031"",
                    ""path"": ""<MidiDevice>/note055"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2baab0c6-ec75-4cda-8e5f-0110342d7e99"",
                    ""path"": ""<MidiDevice>/note056"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3238109b-6363-4f6f-8d2e-4691663f783f"",
                    ""path"": ""<MidiDevice>/note057"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""520b5f56-df91-4253-84ae-09423d9d11e4"",
                    ""path"": ""<MidiDevice>/note058"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9313a9a-bc52-4b70-adcb-a481c50fe86b"",
                    ""path"": ""<MidiDevice>/note059"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52de2143-b4b2-4d3b-9d81-ddc6675519c9"",
                    ""path"": ""<MidiDevice>/note060"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a53aaa9d-d30f-45f7-aaf9-8baf3fe0225a"",
                    ""path"": ""<MidiDevice>/note061"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9203c87-2409-4955-8ee1-2fae9a7cbb51"",
                    ""path"": ""<MidiDevice>/note062"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5dfe483-817d-4a6a-9a8d-aa1a36bb38aa"",
                    ""path"": ""<MidiDevice>/note063"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4cc9e2d-4295-4d42-9e70-c02de8afd69d"",
                    ""path"": ""<MidiDevice>/note064"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f76cda9-a508-4757-a1b8-82bb5986fafb"",
                    ""path"": ""<MidiDevice>/note065"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee617a5d-3686-40fe-8476-b1685254ea66"",
                    ""path"": ""<MidiDevice>/note066"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7f49308-3951-4da2-a71b-130788287e5b"",
                    ""path"": ""<MidiDevice>/note067"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f83d4d93-4d88-4c89-acc9-b23e4079924c"",
                    ""path"": ""<MidiDevice>/note068"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d72b69a-b18a-4b84-b65b-f92f3fda0d25"",
                    ""path"": ""<MidiDevice>/note069"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a015dde-a8ef-4192-9e63-c1eeaf177224"",
                    ""path"": ""<MidiDevice>/note070"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18519084-c1a8-4b9d-b176-c1c578457468"",
                    ""path"": ""<MidiDevice>/note071"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f499e474-4b7d-4a0f-ac77-69b95fb6d5b0"",
                    ""path"": ""<MidiDevice>/note072"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3520909-ad38-470b-9854-23f73e90874a"",
                    ""path"": ""<MidiDevice>/note073"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0b6ac5f-97b4-4353-a530-07d780fdfea1"",
                    ""path"": ""<MidiDevice>/note074"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26fc6aab-155a-439b-a776-0be9b8d0eb8e"",
                    ""path"": ""<MidiDevice>/note075"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6fb1630-e3c7-4be7-a913-c5184aa00389"",
                    ""path"": ""<MidiDevice>/note076"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91a4d0ba-4a23-4f94-8f98-94007f7ec745"",
                    ""path"": ""<MidiDevice>/note077"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""079bb274-1a14-4d79-9235-a3cf142c73b0"",
                    ""path"": ""<MidiDevice>/note078"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32556b42-4b22-4953-849a-ee3ff18ef843"",
                    ""path"": ""<MidiDevice>/note079"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9249cbf-44fd-48eb-94c5-57335b5323de"",
                    ""path"": ""<MidiDevice>/note080"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddb0629a-01e0-4b45-8b59-589f7536710d"",
                    ""path"": ""<MidiDevice>/note081"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a97404f-e919-4b65-9b71-6b9ce613bb45"",
                    ""path"": ""<MidiDevice>/note082"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf6acc70-0c25-440b-b565-a95ac02d3524"",
                    ""path"": ""<MidiDevice>/note083"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8914ad6f-dad2-4272-acb0-1dbb1d3d0fca"",
                    ""path"": ""<MidiDevice>/note084"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd0f27d4-c02d-4ed7-94e6-3fbd18d763bf"",
                    ""path"": ""<MidiDevice>/note085"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2f74180-f7ab-4543-aed2-019ca3f126cf"",
                    ""path"": ""<MidiDevice>/note086"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69511b2e-d487-4dfe-9ee2-f0a63ed27dc9"",
                    ""path"": ""<MidiDevice>/note087"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bef359f3-fc20-429c-b959-bfc4c3c69398"",
                    ""path"": ""<MidiDevice>/note088"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4380b5e0-d204-4f1f-953f-d03fb0294b84"",
                    ""path"": ""<MidiDevice>/note089"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7416873b-e4b4-41c4-a047-1d79bbcf40fb"",
                    ""path"": ""<MidiDevice>/note090"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a7beca0-98b8-4637-b605-09ca28d4af4f"",
                    ""path"": ""<MidiDevice>/note091"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""775d7965-8bff-4906-8439-7f1f58ce0450"",
                    ""path"": ""<MidiDevice>/note092"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9ffc263-248d-4300-83d0-c8d3748e4894"",
                    ""path"": ""<MidiDevice>/note093"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c71ef30-b235-48b6-bc92-634f79fec969"",
                    ""path"": ""<MidiDevice>/note094"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f982d066-b6aa-4bc9-a1ba-20b69c1df799"",
                    ""path"": ""<MidiDevice>/note095"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbcd25fb-b18a-44aa-a968-4d19dc26c9a7"",
                    ""path"": ""<MidiDevice>/note096"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bacaa9d-3315-4f18-b79f-f033f0f274e7"",
                    ""path"": ""<MidiDevice>/note097"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""729ae940-9233-4894-8392-fef17f12709a"",
                    ""path"": ""<MidiDevice>/note098"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8424274-89a5-459e-959c-31e1c241865c"",
                    ""path"": ""<MidiDevice>/note099"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb1b28ca-3f77-44c1-b0fd-31fe2e679551"",
                    ""path"": ""<MidiDevice>/note100"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f974049a-0f16-4fe1-a7a6-c68e7ad8aedc"",
                    ""path"": ""<MidiDevice>/note101"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab26640a-4c3a-4c08-8a8c-f4cb35dffdca"",
                    ""path"": ""<MidiDevice>/note102"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e343324-8707-42e1-9b53-30096fd39003"",
                    ""path"": ""<MidiDevice>/note103"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2940a46b-e5af-4929-9a04-d637e97179de"",
                    ""path"": ""<MidiDevice>/note104"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""124a63fe-6ffc-4231-bff6-37b1cea274bb"",
                    ""path"": ""<MidiDevice>/note105"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31b3f669-cfe7-46a6-8639-60d4f9b89a20"",
                    ""path"": ""<MidiDevice>/note106"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fbc8cc6-e30d-4825-bb12-ffa3e51a2bcd"",
                    ""path"": ""<MidiDevice>/note107"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89555167-99d1-4e8b-9283-5f5b47261642"",
                    ""path"": ""<MidiDevice>/note108"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""508d6a40-e09b-4c2d-a252-332d695ebd33"",
                    ""path"": ""<MidiDevice>/note109"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22298a32-8a08-4ce7-8356-e5734ae0276a"",
                    ""path"": ""<MidiDevice>/note110"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30add540-046f-41b2-90f2-7d7981dfcf43"",
                    ""path"": ""<MidiDevice>/note111"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db0a3a32-9803-469b-95ff-e251a2260c43"",
                    ""path"": ""<MidiDevice>/note112"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c5ac6cc-9a80-461c-9bf8-7fa75b24e76e"",
                    ""path"": ""<MidiDevice>/note113"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""717d3b56-03de-4a8a-a052-f14f1913614b"",
                    ""path"": ""<MidiDevice>/note114"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e534cb4-dd76-4489-b4a9-23ca31175f1e"",
                    ""path"": ""<MidiDevice>/note115"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e6262fc-a066-4bda-a249-776f15521aa6"",
                    ""path"": ""<MidiDevice>/note116"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac48809e-2798-4719-b4a4-11a71cf207e6"",
                    ""path"": ""<MidiDevice>/note117"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd447ab7-7837-4199-b782-2ceb20bbd5bf"",
                    ""path"": ""<MidiDevice>/note118"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e982608-a690-4e22-9043-f6e80f2c31e6"",
                    ""path"": ""<MidiDevice>/note119"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4879c32-510f-4958-8c1b-898f23fd1836"",
                    ""path"": ""<MidiDevice>/note120"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d410f87f-4f2e-4aec-abba-9ab984d83afe"",
                    ""path"": ""<MidiDevice>/note121"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec4a64d5-eaa7-4a4c-9bde-c8132b2ae452"",
                    ""path"": ""<MidiDevice>/note122"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a94e67-1f0d-4c95-8746-c61d32181507"",
                    ""path"": ""<MidiDevice>/note123"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""400d1070-3fef-45a5-8f8a-2f9f87d3bb41"",
                    ""path"": ""<MidiDevice>/note124"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07f64905-331a-4762-a0fa-77407f2575e6"",
                    ""path"": ""<MidiDevice>/note125"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659f4365-afba-48c7-b6d6-0658aedbb776"",
                    ""path"": ""<MidiDevice>/note126"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28890018-acef-4a3b-81c9-39a9158a6edd"",
                    ""path"": ""<MidiDevice>/note127"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""Piano Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""957384f0-b14e-43aa-a7ec-e23001bba058"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""e7ff4da3-28e2-45b9-b0a7-09ed517d3f9e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""78f42a68-12f7-4e88-b5e8-1b6e92edb762"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""408c6e3f-c09e-43e9-8ec7-0359d85a78fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8478e59f-0d8e-46a3-81d5-7554ad2ff141"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ccae6d24-168e-4195-b417-d6a04b6fc79c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2c41fdd5-3702-4995-ac37-ddae111ab84a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d4f384c-8061-41e7-aca3-73e7b0ee697e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eaed106c-bc66-49e6-b47f-ee9ee27318e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2cc5d38d-76c7-45e3-8432-d4aaf120965d"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4eea98ab-03a3-4f0b-ab43-86226b4f2fcb"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""553b130f-571a-4f62-926b-d3ce1d42280d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5b301816-1e98-4595-93b1-954c60102480"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""df43ed98-cd91-477d-b019-87513d009904"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f23f196d-fef6-47f2-b2f9-84e0d349b5c7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a3c464a-22d7-4b5f-a9f4-84338fdee951"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f6ec40e-6381-421e-b106-5f85507a19fe"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06dc48e8-e302-4f0d-b5fa-f86edab5fd18"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9517b273-1031-4dd3-8be1-37dcb33bb68e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ab67f40c-06f6-43ab-9f8b-b9b569b73e61"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""233969f1-118a-4be1-81a6-4b40192ab418"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""4df2993a-2117-40be-bcc6-6df2675d7487"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e1728891-b68a-4173-988f-a210398da071"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d82da35d-8b0e-42d1-9e60-dce2c6694bc8"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""745eaa99-c454-4bf2-82c4-15b607e122ad"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e86efa5d-dbc2-4900-b40e-a9c9d810e46d"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""775e581a-9ec1-4285-b1d0-10eddb86d6c4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fa1adb2c-69ff-403d-9192-2cbcd7d24e06"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9156f3e0-ee6a-4a35-a01f-d5481d8692e2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bb3f5808-e670-44c6-9c67-f969dead99d8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1a7b1be-e713-45ba-a2da-813f03aa4cf6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""35365deb-ff40-461d-93d7-38e7bb7841fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""400ade91-3c16-4b32-b0da-2c32629faa5e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""30bfbc61-54e5-4230-be1c-5b7fb4b95dd3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4db015a9-7af7-4b86-b8d1-3557547fd6c5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61160068-7384-42b1-ad37-1a6694f66bf3"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d8399a2-b05d-4f26-8377-d20f1d57d510"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b7ebe05-6197-451f-bceb-799360d9b0b0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b949ebf0-8db6-4134-bbcc-2c872361a317"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b6316bc-14ea-4e68-9846-91c64abf6ef2"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8df5e5f9-eda7-46e1-9a1c-338d5d7c5866"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3963e63-e448-458f-b592-5fa42bea55ab"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a9cb0f1-4f8d-4286-961a-8091ca2e4c18"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af046c86-a454-4bb3-8e28-8a9b9e4732fd"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fcb65b1-eab1-4f30-90ae-782026be3abc"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""544b39b3-8aea-472e-8854-d56b80c1e3d8"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6520f13-1332-461c-8ac1-df05d8a473c4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c99d3576-da3f-424e-97f4-c5e50927614d"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ba81b8-dfcc-4989-b05d-94fae2ab7a47"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MIDI Device"",
            ""bindingGroup"": ""MIDI Device"",
            ""devices"": [
                {
                    ""devicePath"": ""<MidiDevice>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": []
        }
    ]
}");
        // Piano
        m_Piano = asset.FindActionMap("Piano", throwIfNotFound: true);
        m_Piano_PianoAction = m_Piano.FindAction("Piano Action", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Piano
    private readonly InputActionMap m_Piano;
    private IPianoActions m_PianoActionsCallbackInterface;
    private readonly InputAction m_Piano_PianoAction;
    public struct PianoActions
    {
        private @PianoController m_Wrapper;
        public PianoActions(@PianoController wrapper) { m_Wrapper = wrapper; }
        public InputAction @PianoAction => m_Wrapper.m_Piano_PianoAction;
        public InputActionMap Get() { return m_Wrapper.m_Piano; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PianoActions set) { return set.Get(); }
        public void SetCallbacks(IPianoActions instance)
        {
            if (m_Wrapper.m_PianoActionsCallbackInterface != null)
            {
                @PianoAction.started -= m_Wrapper.m_PianoActionsCallbackInterface.OnPianoAction;
                @PianoAction.performed -= m_Wrapper.m_PianoActionsCallbackInterface.OnPianoAction;
                @PianoAction.canceled -= m_Wrapper.m_PianoActionsCallbackInterface.OnPianoAction;
            }
            m_Wrapper.m_PianoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PianoAction.started += instance.OnPianoAction;
                @PianoAction.performed += instance.OnPianoAction;
                @PianoAction.canceled += instance.OnPianoAction;
            }
        }
    }
    public PianoActions @Piano => new PianoActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    public struct UIActions
    {
        private @PianoController m_Wrapper;
        public UIActions(@PianoController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_MIDIDeviceSchemeIndex = -1;
    public InputControlScheme MIDIDeviceScheme
    {
        get
        {
            if (m_MIDIDeviceSchemeIndex == -1) m_MIDIDeviceSchemeIndex = asset.FindControlSchemeIndex("MIDI Device");
            return asset.controlSchemes[m_MIDIDeviceSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IPianoActions
    {
        void OnPianoAction(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}
