
export const ModalClasses = {
    Outlet: { 
        Base: 'ya-modal-outlet',
        Show: 'ya-modal-outlet-show'
    },
    Backdrop: {
        Base: 'ya-modal-backdrop',
        Shown: 'ya-modal-backdrop-shown',
        Hidden: 'ya-modal-backdrop-hidden'
    },
    Window: {
        Base: 'ya-modal',
        Idle: 'ya-modal-idle',
        Show: 'ya-modal-show',
        Opening: 'ya-modal-opening',
        Closing: 'ya-modal-closing'
    }
} as const;