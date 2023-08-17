module Domain.Error

    [<Struct>]
    type Error = {
        Code: int64
        ErrorMessage: string
    }

