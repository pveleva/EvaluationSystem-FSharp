module Domain.Entities

open System
open OptionTypes

    [<Struct>]
    type Answer = {
        Id: int64
        IsDefault: bool
        Position: int64
        AnswerText: string
        IdQuestion: int64
    }

    [<Struct>]
    type QuestionTemplate = {
        Id: int64
        Name: string
        Type: QuestionType
        IsReusable: bool
        AnswerText: Answer list
    }

    [<Struct>]
    type ModuleTemplate = {
        Id: int64
        Name: string
        QuestionTemplates: QuestionTemplate list
    }

    [<Struct>]
    type ModuleQuestion = {
        Id: int64
        IdModule: int64
        IdQuestion: int64
        Position: int64
    }

    [<Struct>]
    type Form = {
        Id: int64
        Name: string
        ModuleTemplates: ModuleTemplate list
    }

    [<Struct>]
    type FormModule = {
        Id: int64
        IdForm: int64
        IdModule: int64
        Position: int64
    }
