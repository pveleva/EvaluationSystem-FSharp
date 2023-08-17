module Domain.AttestationEntities

open System
open Entities
open OptionTypes

    [<Struct>]
    type AttestationQuestion = {
        Id: int64
        Name: string
        Type: QuestionType
        IsReusable: bool
        DateOfCreation: DateTime
        AnswerText: Answer list
    }

    [<Struct>]
    type AttestationModule = {
        Id: int64
        Name: string
        Description: string
        QuestionTemplates: QuestionTemplate list
    }

    [<Struct>]
    type Attestation = {
        Id: int64
        IdForm: int64
        IdUserToEvaluate: int64
        CreateDate: DateTime
    }

    [<Struct>]
    type AttestationParticipant = {
        Id: int64
        IdAttestation: int64
        IdUserParticipant: int64
        Status: Status
        Position: ParticipantPosition
    }

