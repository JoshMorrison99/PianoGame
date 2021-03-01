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
                    ""name"": ""PianoAction"",
                    ""type"": ""Button"",
                    ""id"": ""49abdaf8-b8b4-4b07-95d8-67e48c883ece"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f2506a4-0321-4a2a-882d-3b3160d66ded"",
                    ""path"": ""<MidiDevice>/note000"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""226f8b6a-c34b-4f6b-b445-eb8edf6de066"",
                    ""path"": ""<MidiDevice>/note001"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8eb5b15-aab5-4242-a1bd-aafd75bedac2"",
                    ""path"": ""<MidiDevice>/note002"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b71da047-81cd-4abf-81ff-90547b1dfba9"",
                    ""path"": ""<MidiDevice>/note003"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b92bcf7f-af90-4b89-afa5-5eee6878337f"",
                    ""path"": ""<MidiDevice>/note004"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""145215b4-b657-4300-a7a9-d5f34ebdd610"",
                    ""path"": ""<MidiDevice>/note005"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d255212-0a38-42e4-82a0-79518bc4b0fe"",
                    ""path"": ""<MidiDevice>/note006"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5409a0cd-70ef-41bb-9005-65618f36a2c3"",
                    ""path"": ""<MidiDevice>/note007"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98726496-2493-4acc-a56e-bc407e7e4af5"",
                    ""path"": ""<MidiDevice>/note008"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4a49b0f-1675-4c46-9181-1e02e3d19ed9"",
                    ""path"": ""<MidiDevice>/note009"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""345ed458-68f3-427c-ba7f-97878fa5c278"",
                    ""path"": ""<MidiDevice>/note010"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d56682ce-8700-4d9a-bfc5-307bde3c3443"",
                    ""path"": ""<MidiDevice>/note011"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8286501a-0e34-47d0-b104-be197057ff56"",
                    ""path"": ""<MidiDevice>/note012"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""565d004b-52f7-4320-a5d0-e9a45d8ccfbf"",
                    ""path"": ""<MidiDevice>/note013"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b44f56e-e9c0-4214-b91a-216aaf689f37"",
                    ""path"": ""<MidiDevice>/note013"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab8b9b41-2c61-4f23-a34e-e40b0a62b766"",
                    ""path"": ""<MidiDevice>/note014"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c94f26b2-4f03-49fe-bab2-ff25eb024fd6"",
                    ""path"": ""<MidiDevice>/note015"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b599a07-b166-4ac9-bb90-ec365b5caa0d"",
                    ""path"": ""<MidiDevice>/note016"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7ecdf6b-05ed-4723-9cac-d4d2ba648596"",
                    ""path"": ""<MidiDevice>/note017"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25bf3682-4370-4014-afe0-925d880867f0"",
                    ""path"": ""<MidiDevice>/note018"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1810467-2ab0-479d-acd5-00c1fe95f621"",
                    ""path"": ""<MidiDevice>/note019"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e78861b-21ea-43b4-929e-a1427a76e07d"",
                    ""path"": ""<MidiDevice>/note020"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4736220-e0fc-4f7a-9082-4021c65c14e7"",
                    ""path"": ""<MidiDevice>/note021"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59188679-10de-4a3c-a626-84c38b06c530"",
                    ""path"": ""<MidiDevice>/note022"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73b8a343-4d1a-48ad-b6f5-d129e1aee507"",
                    ""path"": ""<MidiDevice>/note023"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d627280f-479a-4b7e-b2be-5223d5b1dc2a"",
                    ""path"": ""<MidiDevice>/note024"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3174a72e-59c6-49c7-a20d-78b762ac0bf7"",
                    ""path"": ""<MidiDevice>/note025"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1560d9e-dca3-46ee-a615-c1c4f299237e"",
                    ""path"": ""<MidiDevice>/note026"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29dbf8c5-198c-4092-9e6b-a9be7b4732e0"",
                    ""path"": ""<MidiDevice>/note027"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2530a849-ba7b-46ef-a586-1aaf22894373"",
                    ""path"": ""<MidiDevice>/note028"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05641865-405a-48f3-b44b-f208d6835143"",
                    ""path"": ""<MidiDevice>/note029"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c9e30b0-2265-4b41-9cba-8a0e3e897652"",
                    ""path"": ""<MidiDevice>/note030"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4bcf038-1779-4f64-ac44-2ddd52f1752b"",
                    ""path"": ""<MidiDevice>/note031"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88375dd4-c5ce-48d4-a6f4-8532d9cf71ad"",
                    ""path"": ""<MidiDevice>/note032"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e652165c-3c4a-4401-900e-797d197d0401"",
                    ""path"": ""<MidiDevice>/note033"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab0587cb-e71d-4faa-946b-c3acada519dd"",
                    ""path"": ""<MidiDevice>/note034"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f5ad667-0495-4fc3-83e7-f7b89fc48e14"",
                    ""path"": ""<MidiDevice>/note035"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42a6216b-d483-4098-9196-3f9e19a1a3b7"",
                    ""path"": ""<MidiDevice>/note036"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b7e5ab4-e5b7-4edc-bf49-7b068f70a11e"",
                    ""path"": ""<MidiDevice>/note037"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3708b484-293a-4526-b2ea-508641790bc8"",
                    ""path"": ""<MidiDevice>/note038"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c068093-0f14-4221-aab8-f2c70d256efd"",
                    ""path"": ""<MidiDevice>/note039"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0932be0f-dbdc-4652-9944-353977f05355"",
                    ""path"": ""<MidiDevice>/note040"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bd87a0b-91ac-48d4-9fbf-0d15604d688b"",
                    ""path"": ""<MidiDevice>/note041"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""668f34eb-bfc8-4eb3-ab38-559357ee320e"",
                    ""path"": ""<MidiDevice>/note042"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3a5aafd-b2cf-4399-8715-9b255c5db20a"",
                    ""path"": ""<MidiDevice>/note043"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf74139f-58e9-48a7-916c-969a3554cfc6"",
                    ""path"": ""<MidiDevice>/note044"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e7c0c19-882a-4646-82f8-77a268dd1e17"",
                    ""path"": ""<MidiDevice>/note045"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1d257b1-e92b-4c72-8fa3-726d199ae131"",
                    ""path"": ""<MidiDevice>/note046"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73f0d524-b11e-4c24-acc1-f92448fdc230"",
                    ""path"": ""<MidiDevice>/note047"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b85bf60-01c1-4bf7-a81d-ceff85b7b52f"",
                    ""path"": ""<MidiDevice>/note048"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e232356b-a6e6-400c-b0e7-b69c5a35553c"",
                    ""path"": ""<MidiDevice>/note049"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95f084c3-3fb4-405b-bd09-d1a5d20068ac"",
                    ""path"": ""<MidiDevice>/note050"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88665bef-2d71-4fec-99ad-622d7adce19d"",
                    ""path"": ""<MidiDevice>/note063"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de2cd717-fdc9-4b7f-aebf-a540f5431664"",
                    ""path"": ""<MidiDevice>/note052"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a7d5038-3618-4c71-a323-7678256fa7e1"",
                    ""path"": ""<MidiDevice>/note053"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24992f05-cf79-4287-a6e6-68cbb0ef20c2"",
                    ""path"": ""<MidiDevice>/note054"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""093f8159-1ee9-442a-8b51-8c6b0225e709"",
                    ""path"": ""<MidiDevice>/note055"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff9d0e7f-99db-44cf-af25-637373e94a76"",
                    ""path"": ""<MidiDevice>/note056"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd833579-533f-44cc-bfed-6a4526bd557a"",
                    ""path"": ""<MidiDevice>/note057"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caf25177-31d7-499c-94de-05c18efb4ec3"",
                    ""path"": ""<MidiDevice>/note058"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""790b1c65-7eae-41f7-8392-74a1ddfa2aeb"",
                    ""path"": ""<MidiDevice>/note059"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8392652-f0c2-4bb6-8c6e-7e2eb7bed2e6"",
                    ""path"": ""<MidiDevice>/note060"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c9afbf1-dde4-4f38-9661-31b79f748404"",
                    ""path"": ""<MidiDevice>/note061"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d0f55fc-e29f-493d-9e78-a0446d5cf183"",
                    ""path"": ""<MidiDevice>/note062"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5efaef5-36d4-4e5e-b8f7-712b7c038c60"",
                    ""path"": ""<MidiDevice>/note063"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""251d7c85-96c4-4810-b851-acb26d4d72e9"",
                    ""path"": ""<MidiDevice>/note064"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28121a74-c2bf-4843-ac88-d373bf35177a"",
                    ""path"": ""<MidiDevice>/note065"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44441b3e-1a3f-4aa3-9516-2d94ceb49fb9"",
                    ""path"": ""<MidiDevice>/note066"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4518e6e2-05b7-4a41-874f-c13b6e28c21b"",
                    ""path"": ""<MidiDevice>/note067"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2496b783-8075-45b9-b9ce-3d15837dc98e"",
                    ""path"": ""<MidiDevice>/note068"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82ae3729-afac-4dc8-9a7d-12d1f8f0b800"",
                    ""path"": ""<MidiDevice>/note069"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f170cf9e-848c-41ad-8d51-99bcbf8eb72e"",
                    ""path"": ""<MidiDevice>/note070"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0a8f3df-5cda-456b-bde8-0544b35ca144"",
                    ""path"": ""<MidiDevice>/note071"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b31f3b88-37b6-4394-96d9-0ac61351c0f2"",
                    ""path"": ""<MidiDevice>/note072"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c3958f5-8bbc-41e8-8c05-b4b2bd4360a1"",
                    ""path"": ""<MidiDevice>/note073"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52dd1347-12dd-430f-8966-182a7f4d1a01"",
                    ""path"": ""<MidiDevice>/note074"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb49f16c-f0a4-44bc-92b3-d139de025a55"",
                    ""path"": ""<MidiDevice>/note075"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fabcd3df-0df2-4500-8a1b-92ceabab41ac"",
                    ""path"": ""<MidiDevice>/note076"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b9fb4e3-ddd2-482a-b3f6-85767ba8a6fb"",
                    ""path"": ""<MidiDevice>/note077"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab70eb9d-f633-4928-8e2f-27371bc92f38"",
                    ""path"": ""<MidiDevice>/note078"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f37565dd-b77e-47b6-b2e0-fbbbe8447092"",
                    ""path"": ""<MidiDevice>/note079"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""732bced5-aaac-4d10-985a-bdbfe73d4753"",
                    ""path"": ""<MidiDevice>/note080"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05dc50c5-2ca1-42f6-a484-24cd431413c2"",
                    ""path"": ""<MidiDevice>/note081"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c453745c-96d9-4d6e-ab97-0e2fe9c41a1a"",
                    ""path"": ""<MidiDevice>/note082"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbd7fd3c-b2ae-428c-9676-ef7b065446ad"",
                    ""path"": ""<MidiDevice>/note083"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""842d1afd-bcd7-41b1-aeb9-415735764d01"",
                    ""path"": ""<MidiDevice>/note084"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa28633a-e6a0-4cbb-ae3a-1613e4620e41"",
                    ""path"": ""<MidiDevice>/note085"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc926fec-1754-4aa7-8bf7-9aff86c5c986"",
                    ""path"": ""<MidiDevice>/note086"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb58e051-84a4-42d0-9f4d-7f65f3c9ff5b"",
                    ""path"": ""<MidiDevice>/note087"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1ec52ec-2887-484f-8ccb-40e32fbc477f"",
                    ""path"": ""<MidiDevice>/note088"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db97a1f1-9dac-490a-ac13-27889f8d4d04"",
                    ""path"": ""<MidiDevice>/note089"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b2a2b8-d839-4a36-9698-851645cb7110"",
                    ""path"": ""<MidiDevice>/note090"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28e45c36-ec66-471c-bf86-34a47e93afdd"",
                    ""path"": ""<MidiDevice>/note091"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f95ec12d-a39c-410b-aa23-175b5ba1e441"",
                    ""path"": ""<MidiDevice>/note092"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bfb9144-0739-4c48-81f4-32142684bf0d"",
                    ""path"": ""<MidiDevice>/note093"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0188ab48-1279-4c8c-b42b-8de3052fe746"",
                    ""path"": ""<MidiDevice>/note094"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb5684af-85e1-40ec-b4e3-f9709914e1f4"",
                    ""path"": ""<MidiDevice>/note095"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""180ef834-e988-431e-97d6-f8ece09b4b44"",
                    ""path"": ""<MidiDevice>/note096"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7db599ff-9772-45c6-b4a2-42ee21d035ce"",
                    ""path"": ""<MidiDevice>/note097"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce1ff7f0-fb0f-4861-b6bd-eb7d251a68e2"",
                    ""path"": ""<MidiDevice>/note098"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6fe87cb-fe02-434e-81b8-13075b523923"",
                    ""path"": ""<MidiDevice>/note099"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be0735c7-6aaf-4fa1-8107-ba6fb82acc52"",
                    ""path"": ""<MidiDevice>/note100"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dfdf243-4515-4982-88a8-50ac5e102eb9"",
                    ""path"": ""<MidiDevice>/note101"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82ee57ee-6cb6-45be-aeed-7c1d84869411"",
                    ""path"": ""<MidiDevice>/note102"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6abe4be-2a2a-4840-baab-906632361134"",
                    ""path"": ""<MidiDevice>/note103"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""034748af-acb8-4976-aa05-1973910299f7"",
                    ""path"": ""<MidiDevice>/note104"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36f974ad-db59-460b-af34-9654bef13b9f"",
                    ""path"": ""<MidiDevice>/note105"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce52c3e8-0517-48db-b233-45a9d22f416f"",
                    ""path"": ""<MidiDevice>/note106"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f497a47-ee77-4c13-811a-0225825f73f2"",
                    ""path"": ""<MidiDevice>/note107"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b08b3e7-9af6-4a46-917d-1a3e81e0262d"",
                    ""path"": ""<MidiDevice>/note108"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19ca0cdf-bfd4-4043-92d0-69648442d0a7"",
                    ""path"": ""<MidiDevice>/note109"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1df3ad8c-1a43-4ca6-a0c9-0dff7117b51a"",
                    ""path"": ""<MidiDevice>/note110"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7cc8bbc-b0c9-415a-9292-1e400e108544"",
                    ""path"": ""<MidiDevice>/note111"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1de7f3b-ce69-4daa-b130-bdeaeb10091e"",
                    ""path"": ""<MidiDevice>/note112"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e03dc380-ffe6-49f2-bffb-cc24709cd6ab"",
                    ""path"": ""<MidiDevice>/note113"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""871d0e93-7a90-4474-9e5e-880c2775b1df"",
                    ""path"": ""<MidiDevice>/note114"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42560f5d-e38d-44ba-aa74-d993baebe5ee"",
                    ""path"": ""<MidiDevice>/note115"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a56a720-ed72-4d19-9139-1848579fa630"",
                    ""path"": ""<MidiDevice>/note116"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8be6338-52ea-41dc-bc40-1fa12c2ae014"",
                    ""path"": ""<MidiDevice>/note117"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2690a165-ac02-4579-b1d6-c70ed4c3a3b0"",
                    ""path"": ""<MidiDevice>/note118"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0c5f5e6-8107-450a-96e6-d51ab1f55cb0"",
                    ""path"": ""<MidiDevice>/note119"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ddaba46-93df-498b-ba50-546a4c003888"",
                    ""path"": ""<MidiDevice>/note120"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc38818f-61c6-4d0f-95a4-981c09852078"",
                    ""path"": ""<MidiDevice>/note121"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""079d9cb5-2fca-44d0-954b-5c4bed954637"",
                    ""path"": ""<MidiDevice>/note122"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bcd9c39-76ea-4e5f-b660-fc3b455d7626"",
                    ""path"": ""<MidiDevice>/note123"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4abb94f-70c5-47c7-82d6-2541e5927bfd"",
                    ""path"": ""<MidiDevice>/note124"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6111d98e-94cd-4534-bd21-5c3c59cf24cf"",
                    ""path"": ""<MidiDevice>/note125"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4afd6c7-e7ca-43eb-9086-5ef7c432227d"",
                    ""path"": ""<MidiDevice>/note126"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""679cda5d-8e71-4749-8dfd-391594be717c"",
                    ""path"": ""<MidiDevice>/note127"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MIDI Device"",
                    ""action"": ""PianoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""9e189527-c2d1-4a8a-a37c-ede49adfab0e"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""f0227b08-de33-45bf-ae78-041707a44957"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""8b04391f-b439-4837-aa7e-61d45fc9897b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""59c37b13-b0c9-4303-888e-291c5bff4d4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fc312bc-efbf-4f03-86b6-c397aed4e82b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f29d6087-5f86-4542-bf9c-aa4ac2bdf675"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""074e163e-50b5-4f2a-b9ea-201a4db82f46"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bad02056-e33f-496e-b349-4c2bf4c58789"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0112e319-301f-426a-80d4-07b0c32da70f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""402138e5-e294-494e-b226-b3f4a7575690"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5890c607-2319-4a1e-b2fb-44d81e3f9e40"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""c986c4b3-c97c-4a83-923f-ed11c05255f8"",
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
                    ""id"": ""5eb56cd6-7495-40e0-9bfe-101afdb61ebf"",
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
                    ""id"": ""cd9f06f9-c483-41f5-8722-a30cdcb983cc"",
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
                    ""id"": ""67b79313-5c17-416f-acbd-723deee8698c"",
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
                    ""id"": ""16177371-f46b-470a-ac16-054bfb0e6d25"",
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
                    ""id"": ""60eb6779-8472-4879-ac73-414c2059f4ad"",
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
                    ""id"": ""efda3798-5cd2-46b8-81e0-72921a53345b"",
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
                    ""id"": ""5c374256-b219-4ae7-9ec1-818cebd3be30"",
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
                    ""id"": ""961332da-a70f-47f1-85fb-e1161f1f4ac7"",
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
                    ""id"": ""48f5c7cf-cfb2-48b0-bea1-54c80904d445"",
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
                    ""id"": ""cb816311-8579-4409-9b8b-1140bb928e7f"",
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
                    ""id"": ""caf8c2a7-8141-459c-af20-410960ae67f9"",
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
                    ""id"": ""94c6c185-2f31-4015-9cdb-2a4461981763"",
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
                    ""id"": ""f28067c5-e705-4978-8bb7-5331d56a0b26"",
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
                    ""id"": ""7251e948-86c0-4c8a-b0d1-cab0a175ffb6"",
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
                    ""id"": ""d6a6bdee-b322-4a71-9d2d-18f2da66f04e"",
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
                    ""id"": ""26df86b9-c0e7-4afd-93c9-7e9d036ade95"",
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
                    ""id"": ""7bdeeab1-928f-437b-8c04-c03b7729e986"",
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
                    ""id"": ""e5518a1e-c88f-412c-b8aa-7e6b13082ef1"",
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
                    ""id"": ""c2aafd84-e204-40b3-922e-8cf73a2f9495"",
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
                    ""id"": ""52427bb8-a2bd-4852-ad62-782b83695069"",
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
                    ""id"": ""21a0e533-e34f-434e-b6c4-ba55b4e629ca"",
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
                    ""id"": ""05e23d3d-e324-4627-ba22-4c4f98ff7be4"",
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
                    ""id"": ""020f7ef0-0de1-4842-a1fb-db34eead75e8"",
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
                    ""id"": ""ef21686e-b057-447a-abd9-953ede784183"",
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
                    ""id"": ""b186ce18-6a5a-4950-83da-29bf6f678243"",
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
                    ""id"": ""fb62bc5c-5cf3-4659-bca5-64c0128130be"",
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
                    ""id"": ""4f971d47-b2cd-4d4c-97a9-253f85bd8b74"",
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
                    ""id"": ""18d616d1-27c3-4727-b392-7d43269bb0c7"",
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
                    ""id"": ""5a1c7f49-43e1-4d55-8a40-efee44b19bd2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15e58173-e2fa-404a-9838-ae87594bd5ee"",
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
                    ""id"": ""bd531097-c12e-4f4f-9fab-dfa5500da249"",
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
                    ""id"": ""dcbe8008-8ba6-412a-aaa6-fb6877ee1fb5"",
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
                    ""id"": ""4a022512-1d1e-48ca-b394-5c632f27c083"",
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
                    ""id"": ""cbf0e5ce-cb75-4d14-9199-00270e1d6120"",
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
                    ""id"": ""86f246f4-08e0-4d12-a926-99d92d4d98ab"",
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
                    ""id"": ""2f53925d-8796-471b-98c5-b4e0c133cf23"",
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
                    ""id"": ""3c367257-eb9a-411a-a56d-42af04cfe1f7"",
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
        m_Piano_PianoAction = m_Piano.FindAction("PianoAction", throwIfNotFound: true);
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
