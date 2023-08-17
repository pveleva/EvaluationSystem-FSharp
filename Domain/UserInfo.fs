module Domain.UserInfo

    [<Struct>]
    type User = {
        Id: int64
        Email: string
        Name: string
    }

    [<Struct>]
    type UserAnswer = {
        Id: int64
        IdAttestation: int64
        IdUserParticipant: int64
        IdAttestationModule: int64
        IdAttestationQuestion: int64
        IdAttestationAnswer: int64
        TextAnswer: string
    }


