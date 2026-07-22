import { GridIcon } from "../../assets/icons";
import { Module } from "../../components/layout/Sidebar/types";

export const dashboardModule : Module = {
    icon: <GridIcon />,
    name: "Dashboard",
    subModules: [
        { 
            name: "Home", 
            path: "/", 
        }
    ]
}