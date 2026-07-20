export interface IModule {
    index?: boolean;
    icon: React.ReactNode;
    moduleName: string;
    subModuleName: string;
    path: string;
    element: React.ReactNode;
}