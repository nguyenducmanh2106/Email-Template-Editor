import { Routes, Route } from 'react-router-dom';

import DesignList from './DesignList';
import DesignEdit from './DesignEdit';
import DesignNew from './DesignNew';

const Dashboard = () => {
  return (
    <Routes>
      <Route path="/" element={<DesignList />} />
      <Route path={`design/new`} element={<DesignNew />} />
      <Route path={`/design/edit/:designId`} element={<DesignEdit />} />
    </Routes>
  );
};

export default Dashboard;
