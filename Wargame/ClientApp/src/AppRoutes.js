import { Home } from "./components/Home";
import Countries from "./components/Countries"
import Types  from "./components/Types"
import Properties from "./components/Properties"
import Roles from "./components/Roles"
import Movements from "./components/Movements";
import Armaments from "./components/Armaments";
import ArmamentsCreate from "./components/ArmamentsCreate";
import Tanks from "./components/Tanks";
import TanksCreate from "./components/TanksCreate";

const AppRoutes = [
  {index: true,
    element: <Home />},
  {path: '/menuType',
    element: <Types />},
  {path: '/menuCountry',
    element: <Countries />},
  {path: '/menuProperty',
    element: <Properties />},
  {path: '/menuRole',
    element: <Roles />},
  {path: '/menuMovement',
    element: <Movements />},
  {path: '/menuArmament',
    element: <Armaments/>},
  {path: '/menuArmament/createArmament',
    element: <ArmamentsCreate/>},
  {path: '/menuArmament/updateArmament/:armamentId',
    element: <ArmamentsCreate/>},
  {path: '/menuTank',
    element: <Tanks/>},
  {path: '/menuTank/createTank',
    element: <TanksCreate/>},
  {path: '/menuTank/updateTank/:tankId',
    element: <TanksCreate/>},
];

export default AppRoutes;
