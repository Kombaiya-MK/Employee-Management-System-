
import './App.css';
import Navbar from './components/Navbar'
import { BrowserRouter,Route,Routes } from 'react-router-dom';
import Home from './components/Home';
import AddEmployees from './components/AddEmployees';
import UpdateEmployees from './components/UpdateEmployees';
import 'bootstrap/dist/css/bootstrap.css';
import Profile from './components/Profile';

function App() {
  return (
    <BrowserRouter>
        <Navbar/>
        <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='create' element={<AddEmployees/>}/>
        <Route path='list' element={<UpdateEmployees/>}/>
        <Route path='profile' element={<Profile/>}/>
        </Routes>
   
      </BrowserRouter>
  );
}

export default App;
