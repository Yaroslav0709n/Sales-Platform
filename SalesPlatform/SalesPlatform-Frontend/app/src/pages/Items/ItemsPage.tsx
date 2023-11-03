import React from 'react';
import Items from '../../components/Items/ItemsList'
import Container from '../../shared/Containers/Container'
import Title from '../../shared/Title/Title';

const ItemsPage: React.FC = () => {
  return (
  <Container>
    <Title>Advertisement</Title>
    <Items/>
  </Container> 
  );
};

export default ItemsPage;