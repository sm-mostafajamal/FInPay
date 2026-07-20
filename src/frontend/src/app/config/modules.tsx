import { CalenderIcon, GridIcon } from "../../assets/icons";
import { Module } from "../../components/layout/Sidebar/types";

export const modules: Module[] = [
  {
    icon: <GridIcon />,
    name: "Dashboard",
    subModules: [
      { 
        name: "Home", 
        path: "/", 
      },
      {
        name: "Calendar",
        path: "/calendar",
      }
    ],
  },
];