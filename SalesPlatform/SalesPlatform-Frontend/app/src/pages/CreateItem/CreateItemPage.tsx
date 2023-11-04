import React from 'react';
import Container from '../../shared/Containers/Container'
import Title from '../../shared/Title/Title';
import CreateItem from '../../components/Items/Create/CreateItem';

const CreateItemPage: React.FC = () => {
  return (
  <Container>
    <Title>Create Advertisement</Title>
    <CreateItem/>
  </Container>  
  );
};

export default CreateItemPage;